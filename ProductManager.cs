using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Soft_Update
{
    public class ProductManager
    {
        SqlHelper databaseMan = new SqlHelper();
        public ProductManager()
        {
            databaseMan.ConnectionString = PublicSetting.GetParameterA();
        }
        /// <summary>
        /// 加载产品列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetProductList()
        {
            DataTable result = new DataTable();
            string sql = "select [PRODUCT_CODE],[PRODUCT_NAME],[PRCESS_NAME],[PRODUCT_VERSION],[PRODUCT_VERSION2] from TB_PRODUCT order by product_name ";
            result = this.databaseMan.ExecuteDataSet(sql).Tables[0];
            return result;
        }

        /// <summary>
        /// 加载产品列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetProduct(string PRODUCT_CODE)
        {
            DataTable result = new DataTable();
            string sql =string.Format("select [PRODUCT_CODE],[PRODUCT_NAME],[PRCESS_NAME],[PRODUCT_VERSION],[PRODUCT_VERSION2] from TB_PRODUCT where PRODUCT_CODE='{0}' order by product_name ",PRODUCT_CODE);
            result = this.databaseMan.ExecuteDataSet(sql).Tables[0];
            return result;
        }

        public int AddProduct(DataRow row)
        {
            string strSQL = @"INSERT INTO [TB_PRODUCT]([PRODUCT_CODE] ,[PRODUCT_NAME],[PRCESS_NAME] ,[PRODUCT_VERSION],[PRODUCT_VERSION2])
                VALUES(@PRODUCT_CODE,@PRODUCT_NAME,@PRCESS_NAME,@PRODUCT_VERSION,@PRODUCT_VERSION2)";
            SqlParameter[] pars = new System.Data.SqlClient.SqlParameter[]
            {
                new System.Data.SqlClient.SqlParameter("@PRODUCT_CODE",row["PRODUCT_CODE"]),
                new System.Data.SqlClient.SqlParameter("@PRODUCT_NAME",row["PRODUCT_NAME"]),
                new System.Data.SqlClient.SqlParameter("@PRCESS_NAME",row["PRCESS_NAME"]),
                new System.Data.SqlClient.SqlParameter("@PRODUCT_VERSION",row["PRODUCT_VERSION"]),
                new System.Data.SqlClient.SqlParameter("@PRODUCT_VERSION2",row["PRODUCT_VERSION2"])
            };
            return databaseMan.ExecuteNonQuery(strSQL, pars);
        }
        /// <summary>
        /// 删除产品数据
        /// </summary>
        /// <param name="PRODUCT_CODE"></param>
        /// <returns></returns>
        public int DeleteProduct(string PRODUCT_CODE)
        {
            string strSQL = @"DELETE [TB_PRODUCT] WHERE [PRODUCT_CODE]=@PRODUCT_CODE";
            SqlParameter[] pars = new System.Data.SqlClient.SqlParameter[]
            {
                new System.Data.SqlClient.SqlParameter("@PRODUCT_CODE",PRODUCT_CODE)
            };
            return databaseMan.ExecuteNonQuery(strSQL, pars);
        }

        public int UpdateProduct(DataRow row)
        {
            string strSQL = @"UPDATE [TB_PRODUCT] SET [PRODUCT_NAME]=@PRODUCT_NAME,[PRCESS_NAME]=@PRCESS_NAME,[PRODUCT_VERSION]=@PRODUCT_VERSION
                                 ,[PRODUCT_VERSION2]=@PRODUCT_VERSION2 WHERE [PRODUCT_CODE]=@PRODUCT_CODE";
            SqlParameter[] pars = new System.Data.SqlClient.SqlParameter[]
            {
                new System.Data.SqlClient.SqlParameter("@PRODUCT_CODE",row["PRODUCT_CODE"]),
                new System.Data.SqlClient.SqlParameter("@PRODUCT_NAME",row["PRODUCT_NAME"]),
                new System.Data.SqlClient.SqlParameter("@PRCESS_NAME",row["PRCESS_NAME"]),
                new System.Data.SqlClient.SqlParameter("@PRODUCT_VERSION",row["PRODUCT_VERSION"]),
                new System.Data.SqlClient.SqlParameter("@PRODUCT_VERSION2",row["PRODUCT_VERSION2"])
            };
            return databaseMan.ExecuteNonQuery(strSQL, pars);
        }

        /// <summary>
        /// 获取最大的版本号数值
        /// </summary>
        /// <param name="PRODUCT_CODE"></param>
        /// <returns></returns>
        public int GetVersion(string PRODUCT_CODE)
        {
            string strSQL = @"SELECT PRODUCT_VERSION FROM TB_PRODUCT WHERE [PRODUCT_CODE]=@PRODUCT_CODE";
            SqlParameter[] pars = new System.Data.SqlClient.SqlParameter[]
            {
                new System.Data.SqlClient.SqlParameter("@PRODUCT_CODE",PRODUCT_CODE)
            };
            return Convert.ToInt32( databaseMan.ExecuteScalar(strSQL, pars));
        }
    }
}
