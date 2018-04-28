using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Soft_Update
{
    public class ProductFileManager
    {
        SqlHelper databaseMan = new SqlHelper();
        public ProductFileManager()
        {
            databaseMan.ConnectionString = PublicSetting.GetParameterA();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetProductFileList(string PRODUCT_CODE)
        {
            DataTable result = new DataTable();
            string sql = "select [PRODUCT_CODE],[PRODUCT_FILENAME] from TB_PRODUCTFILE WHERE PRODUCT_CODE=@PRODUCT_CODE order by PRODUCT_CODE ";
            SqlParameter[] pars = new System.Data.SqlClient.SqlParameter[]
            {
                new System.Data.SqlClient.SqlParameter("@PRODUCT_CODE",PRODUCT_CODE)
            };
            result = this.databaseMan.ExecuteDataSet(sql,pars).Tables[0];
            return result;
        }

        public int AddProductFile(DataRow row)
        {
            string strSQL = @"INSERT INTO [TB_PRODUCTFILE]([PRODUCT_CODE] ,[PRODUCT_FILENAME])
                VALUES(@PRODUCT_CODE,@PRODUCT_FILENAME)";
            SqlParameter[] pars = new System.Data.SqlClient.SqlParameter[]
            {
                new System.Data.SqlClient.SqlParameter("@PRODUCT_CODE",row["PRODUCT_CODE"]),
                new System.Data.SqlClient.SqlParameter("@PRODUCT_FILENAME",row["PRODUCT_FILENAME"])
            };
            return databaseMan.ExecuteNonQuery(strSQL, pars);
        }
        /// <summary>
        /// 删除产品默认升级数据
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public int DeleteProductFile(DataRow row)
        {
            string strSQL = @"DELETE [TB_PRODUCTFILE] WHERE [PRODUCT_CODE]=@PRODUCT_CODE AND PRODUCT_FILENAME=@PRODUCT_FILENAME";
            SqlParameter[] pars = new System.Data.SqlClient.SqlParameter[]
            {
                new System.Data.SqlClient.SqlParameter("@PRODUCT_CODE",row["PRODUCT_CODE",DataRowVersion.Original]),
                new System.Data.SqlClient.SqlParameter("@PRODUCT_FILENAME",row["PRODUCT_FILENAME",DataRowVersion.Original])
            };
            return databaseMan.ExecuteNonQuery(strSQL, pars);
        }

        public int UpdateProductFile(DataRow row)
        {
            string strSQL = @"UPDATE [TB_PRODUCTFILE] SET [PRODUCT_FILENAME]=@PRODUCT_FILENAMEN
                                 WHERE [PRODUCT_CODE]=@PRODUCT_CODE AND PRODUCT_FILENAME=@PRODUCT_FILENAMEO";
            SqlParameter[] pars = new System.Data.SqlClient.SqlParameter[]
            {
                new System.Data.SqlClient.SqlParameter("@PRODUCT_CODE",row["PRODUCT_CODE"]),
                new System.Data.SqlClient.SqlParameter("@PRODUCT_FILENAMEN",row["PRODUCT_FILENAME"]),
                new System.Data.SqlClient.SqlParameter("@PRODUCT_FILENAMEO",row["PRODUCT_FILENAME",DataRowVersion.Original])
            };
            return databaseMan.ExecuteNonQuery(strSQL, pars);
        }
    }
}
