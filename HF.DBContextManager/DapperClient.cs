using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using Dapper;

using Microsoft.Extensions.Options;


namespace HF.DBContextManager
{

    /// <summary>
    ///  数据库操作类
    /// </summary>
    public class DapperClient
    {
        /// <summary>
        /// 
        /// </summary>
        public ConnectionConfig CurrentConnectionConfig { get; set; }

        public DapperClient(IOptionsMonitor<ConnectionConfig> config)
        {
            CurrentConnectionConfig = config.CurrentValue;
        }

        public DapperClient(ConnectionConfig config) { CurrentConnectionConfig = config; }

        IDbConnection _connection = null;
        public IDbConnection Connection
        {
            get
            {
                switch (CurrentConnectionConfig.DbType)
                {
                    case DBStoreType.MySql:
                        _connection = new MySql.Data.MySqlClient.MySqlConnection(CurrentConnectionConfig.ConnectionString);
                        break;
                    case DBStoreType.SqlServer:
                        _connection = new System.Data.SqlClient.SqlConnection(CurrentConnectionConfig.ConnectionString);
                        break;
                    case DBStoreType.Oracle:
                        _connection = new Oracle.ManagedDataAccess.Client.OracleConnection(CurrentConnectionConfig.ConnectionString);
                        break;
                    default:
                        throw new Exception("未指定数据库类型！");
                }
                return _connection;
            }
        }

        /// <summary>
        /// 执行SQL返回集合
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns></returns>
        public virtual List<T> Query<T>(string strSql)
        {
            using IDbConnection conn = Connection;
            return conn.Query<T>(strSql, null).AsList();
        }

        /// <summary>
        /// 异步执行SQL返回集合
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns></returns>
        public virtual async Task<List<T>> QueryAsync<T>(string strSql)
        {
            using IDbConnection conn = Connection;
            var res = await conn.QueryAsync<T>(strSql);
            return res.ToList<T>();
        }



        /// <summary>
        /// 执行SQL返回集合
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <param name="obj">参数model</param>
        /// <returns></returns>
        public virtual List<T> Query<T>(string strSql, object param)
        {
            using IDbConnection conn = Connection;
            return conn.Query<T>(strSql, param).AsList();
        }

        /// <summary>
        /// 异步执行SQL返回集合
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns></returns>
        public virtual async Task<List<T>> QueryAsync<T>(string strSql, object param)
        {
            using IDbConnection conn = Connection;
            var res = await conn.QueryAsync<T>(strSql, param);
            return res.ToList<T>();
        }

        /// <summary>
        /// 执行SQL返回一个对象
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns></returns>
        public virtual T QueryFirst<T>(string strSql)
        {
            using IDbConnection conn = Connection;
            return conn.Query<T>(strSql).FirstOrDefault<T>();
        }

        /// <summary>
        /// 异步执行SQL返回一个对象
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns></returns>
        public virtual async Task<T> QueryFirstAsync<T>(string strSql)
        {
            using IDbConnection conn = Connection;
            var res = await conn.QueryAsync<T>(strSql);
            return res.FirstOrDefault<T>();
        }

        /// <summary>
        /// 执行SQL返回一个对象
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <param name="obj">参数model</param>
        /// <returns></returns>
        public virtual T QueryFirst<T>(string strSql, object param)
        {
            using IDbConnection conn = Connection;
            return conn.Query<T>(strSql, param).FirstOrDefault<T>();
        }

        /// <summary>
        /// 异步执行SQL返回一个对象
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns></returns>
        public virtual async Task<T> QueryFirstAsync<T>(string strSql, object param)
        {
            using IDbConnection conn = Connection;
            var res = await conn.QueryAsync<T>(strSql, param);
            return res.FirstOrDefault<T>();
        }

        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <param name="param">参数</param>
        /// <returns>返回影响条数</returns>
        public virtual int Execute(string strSql, object param)
        {
            using IDbConnection conn = Connection;
            try
            {
                return conn.Execute(strSql, param);
                //return conn.Execute(strSql, param) > 0 ? 0 : -1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="strProcedure">过程名</param>
        /// <returns></returns>
        public virtual int ExecuteStoredProcedure(string strProcedure)
        {
            using IDbConnection conn = Connection;
            try
            {
                return conn.Execute(strProcedure, null, null, null, CommandType.StoredProcedure) == 0 ? 0 : -1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="strProcedure">过程名</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public virtual int ExecuteStoredProcedure(string strProcedure, object param)
        {
            using IDbConnection conn = Connection;
            try
            {
                return conn.Execute(strProcedure, param, null, null, CommandType.StoredProcedure) == 0 ? 0 : -1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
