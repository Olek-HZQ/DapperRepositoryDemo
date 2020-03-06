﻿using CoreDapperRepository.Core;
using CoreDapperRepository.Core.Constants;
using CoreDapperRepository.Core.Domain;
using SqlKata;
using SqlKata.Compilers;

namespace CoreDapperRepository.Data.Repositories.Mysql
{
    public class MysqlRepositoryBase<T> : RepositoryBase<T> where T : BaseEntity
    {
        protected sealed override DatabaseType DataType => DatabaseType.Mysql;

        /// <inheritdoc />
        /// <summary>
        /// 当前数据库连接串的key(默认主数据库key)
        /// </summary>
        protected override string ConnStrKey => ConnKeyConstants.MysqlMasterKey;

        /// <inheritdoc />
        /// <summary>
        /// 数据表名(默认类名，如果不是，需要在子类重写)
        /// </summary>
        protected override string TableName => typeof(T).Name;

        protected override SqlResult GetSqlResult(Query query)
        {
            var compiler = new MySqlCompiler();

            SqlResult sqlResult = compiler.Compile(query);

            return sqlResult;
        }
    }
}
