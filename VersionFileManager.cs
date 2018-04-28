using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Soft_Update
{
    public class VersionFileManager
    {
        SqlHelper databaseMan = new SqlHelper();
        public VersionFileManager()
        {
            databaseMan.ConnectionString = PublicSetting.GetParameterA();
        }
        
        public int AddVersionFile(DataRow row)
        {
            string strSQL = @"INSERT INTO TB_VERSIONFILE ([OBJ_NO],[PRODUCT_CODE],[FILE_VERSION],[FILE_VERSION],[FILE_NAME],[FILE_PATH],[FILE_DATA],[OBJ_DATE],[REMARK])
                VALUES(@OBJ_NO,@PRODUCT_CODE,@FILE_VERSION,@FILE_VERSION2,@FILE_NAME,@FILE_PATH,@FILE_DATA,GETDATE(),@REMARK)";
            SqlParameter[] pars = new System.Data.SqlClient.SqlParameter[]
            {
                new System.Data.SqlClient.SqlParameter("@OBJ_NO",row["OBJ_NO"]),
                new System.Data.SqlClient.SqlParameter("@PRODUCT_CODE",row["PRODUCT_CODE"]),
                new System.Data.SqlClient.SqlParameter("@FILE_VERSION",row["FILE_VERSION"]),
                new System.Data.SqlClient.SqlParameter("@FILE_VERSION2",row["FILE_VERSION2"]),
                new System.Data.SqlClient.SqlParameter("@FILE_NAME",row["FILE_NAME"]),
                new System.Data.SqlClient.SqlParameter("@FILE_PATH",row["FILE_PATH"]),
                new System.Data.SqlClient.SqlParameter("@FILE_DATA",row["FILE_DATA"]),
                new System.Data.SqlClient.SqlParameter("@REMARK",row["REMARK"])
            };
            return databaseMan.ExecuteNonQuery(strSQL, pars);
        }

        /// <summary>
        /// 查询文件列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            string strSQL = @"SELECT [OBJ_NO],[PRODUCT_CODE],[FILE_VERSION],[FILE_VERSION2],[FILE_NAME],[FILE_PATH],[FILE_DATA],[OBJ_DATE],[REMARK] FROM TB_VERSIONFILE";
            if (!string.IsNullOrWhiteSpace(where))
                strSQL += (" where " + where);
            return databaseMan.ExecuteDataSet(strSQL).Tables[0];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProductCode"></param>
        /// <param name="Version"></param>
        /// <param name="FileData"></param>
        /// <returns></returns>
        public bool UpFile(DataRow row)
        {
            bool result = false;
            //删除相同的文件
            string sql = "delete TB_VERSIONFILE where  FILE_NAME = @FILE_NAME and FILE_VERSION = @FILE_VERSION and PRODUCT_CODE = @PRODUCT_CODE";
            System.Data.SqlClient.SqlParameter[] pars1 = new System.Data.SqlClient.SqlParameter[]
            {
                new System.Data.SqlClient.SqlParameter("@FILE_NAME",row["FILE_NAME"]),
                new System.Data.SqlClient.SqlParameter("@FILE_VERSION",row["FILE_VERSION"]),
                new System.Data.SqlClient.SqlParameter("@PRODUCT_CODE",row["PRODUCT_CODE"])
            };
            databaseMan.ExecuteNonQuery(sql, pars1);

            //更新版本号
            sql = "update TB_PRODUCT set PRODUCT_VERSION = @PRODUCT_VERSION,PRODUCT_VERSION2 = @PRODUCT_VERSION2 where PRODUCT_CODE = @PRODUCT_CODE";
            System.Data.SqlClient.SqlParameter[] pars2 = new System.Data.SqlClient.SqlParameter[]
            {
                new System.Data.SqlClient.SqlParameter("@PRODUCT_VERSION",row["FILE_VERSION"]),
                new System.Data.SqlClient.SqlParameter("@PRODUCT_VERSION2",row["FILE_VERSION2"]),
                new System.Data.SqlClient.SqlParameter("@PRODUCT_CODE",row["PRODUCT_CODE"])
            };
            if (databaseMan.ExecuteNonQuery(sql, pars2) > 0)
            {
                //插入文件
                sql = "insert into TB_VERSIONFILE([OBJ_NO],[PRODUCT_CODE],[FILE_VERSION],[FILE_VERSION2],[FILE_NAME],[FILE_PATH],[FILE_DATA],[OBJ_DATE],[REMARK]) " +
                    "values(@OBJ_NO,@PRODUCT_CODE,@FILE_VERSION,@FILE_VERSION2,@FILE_NAME,@FILE_PATH,@FILE_DATA,getdate(),@REMARK)";
                System.Data.SqlClient.SqlParameter[] pars = new System.Data.SqlClient.SqlParameter[8];
                pars[0] = new System.Data.SqlClient.SqlParameter("@OBJ_NO", row["OBJ_NO"]);
                pars[1] = new System.Data.SqlClient.SqlParameter("@PRODUCT_CODE", row["PRODUCT_CODE"]);
                pars[2] = new System.Data.SqlClient.SqlParameter("@FILE_VERSION", row["FILE_VERSION"]);
                pars[3] = new System.Data.SqlClient.SqlParameter("@FILE_VERSION2", row["FILE_VERSION2"]);
                pars[4] = new System.Data.SqlClient.SqlParameter("@FILE_NAME", row["FILE_NAME"]);
                pars[5] = new System.Data.SqlClient.SqlParameter("@FILE_PATH", row["FILE_PATH"]);
                pars[6] = new System.Data.SqlClient.SqlParameter("@file_data", SqlDbType.Image);
                pars[6].Value = row["file_data"];
                pars[7] = new System.Data.SqlClient.SqlParameter("@REMARK", row["REMARK"]);

                if (databaseMan.ExecuteNonQuery(sql, pars) > 0)
                    result = true;
            }
            return result;
        }

        /// <summary>
        /// 得到要下载的清单
        /// </summary>
        /// <param name="File_Version">本地的版本数值</param>
        /// <returns></returns>
        public DataTable GetDownLoadList(int File_Version)
        {
            DataTable dtData = null;
            string sql =string.Format( @"  declare @dtUpdate table(PRODUCT_CODE uniqueidentifier,FILE_NAME varchar(50),FILE_PATH varchar(100),FILE_VERSION int)
  insert into @dtUpdate
  select PRODUCT_CODE,FILE_NAME,FILE_PATH,MAX(FILE_VERSION) from TB_VERSIONFILE
  where file_version > {0}
                                                            group by PRODUCT_CODE,FILE_NAME,FILE_PATH

                                                            select v.* from @dtUpdate u inner
                                                                       join TB_VERSIONFILE v

on u.PRODUCT_CODE = v.PRODUCT_CODE and u.FILE_NAME = v.FILE_NAME and u.FILE_PATH = v.FILE_PATH and u.FILE_VERSION = v.FILE_VERSION",File_Version);
            DataSet ds = this.databaseMan.ExecuteDataSet(sql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dtData = ds.Tables[0];
            }
            return dtData;
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="obj_no"></param>
        /// <returns></returns>
        public byte[] GetFile(string obj_no)
        {
            byte[] result = null;
            string sql = "select file_data from TB_VERSIONFILE where obj_no = '{0}' ";
            sql = string.Format(sql, obj_no);
            object value = databaseMan.ExecuteScalar(sql);
            if (value != null)
                result = (byte[])value;
            return result;
        }
    }
}
