using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Soft_Update
{
    public class VersionManager
    {
        SqlHelper databaseMan = new SqlHelper();
        public VersionManager()
        {
            databaseMan.ConnectionString = PublicSetting.GetParameterA();
        }

        /// <summary>
        /// 取服务器版本号
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string GetServerVersion(UpdateDataContract request)
        {
            string result = "1.0";
            string sql = "select version from sd_version where product_code = '" + request.ProductCode + "'";
            result = databaseMan.ExecuteScalar(sql).ToString();
            return result;
        }

        public string GetServerVersionNew(UpdateDataContract request)
        {
            string result = "1.0";
            string sql = "select PRODUCT_VERSION from TB_PRODUCT where PRODUCT_CODE = '" + request.ProductCode + "'";
            result = databaseMan.ExecuteScalar(sql).ToString();
            return result;
        }

        /// <summary>
        /// 得到要下载的清单
        /// </summary>
        /// <param name="ProductCode"></param>
        /// <param name="VersionNo"></param>
        /// <returns></returns>
        public List<VersionFileDataContract> GetDownLoadList(string ProductCode,string VersionNo)
        {
            List<VersionFileDataContract> result = new List<VersionFileDataContract>();
            string sql = "select * from VERSION_FILE where product_code = '{0}' and version = '{1}'";
            sql = string.Format(sql, ProductCode, VersionNo);
            DataSet ds = this.databaseMan.ExecuteDataSet(sql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    VersionFileDataContract versionFile = new VersionFileDataContract();
                    versionFile.GuidNo = row["obj_no"].ToString();
                    versionFile.ProductCode = row["product_code"].ToString();
                    versionFile.Version = row["version"].ToString();
                    versionFile.FileName = row["file_name"].ToString();
                    versionFile.FilePath = row["file_path"].ToString();
                    result.Add(versionFile);
                }
            }
            return result;
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public byte[] GetFile(VersionFileDataContract file)
        {
            byte[] result = null;
            string sql = "select file_data from VERSION_FILE where obj_no = '{0}' ";
            sql = string.Format(sql, file.GuidNo);
            object value = databaseMan.ExecuteScalar(sql);
            if (value != null)
                result = (byte[])value;
            return result;
        }

        /// <summary>
        /// 得到产品列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetProductList()
        {
            DataSet result = new DataSet();
            string sql = "select product_code,product_name,version from sd_version order by product_name ";
            result = this.databaseMan.ExecuteDataSet(sql);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProductCode"></param>
        /// <param name="Version"></param>
        /// <param name="FileData"></param>
        /// <returns></returns>
        public bool UploadFile(string ProductCode,string FileName, string Version, byte[] FileData)
        {
            bool result = false;
            //删除相同的文件
            string sql = "delete version_file where  FILE_NAME = '{0}' and VERSION = '{1}' and product_code = '{2}'";
            sql = string.Format(sql, FileName, Version, ProductCode);
            databaseMan.ExecuteNonQuery(sql);

            //更新版本号
            sql = "update sd_version set version = '{0}' where product_code = '{1}'";
            sql = string.Format(sql, Version, ProductCode);
            if (databaseMan.ExecuteNonQuery(sql) > 0)
            {
                //插入文件
                sql = "insert into version_file(obj_no,product_code,version,file_name,file_data,obj_date) " +
                    "values(newid(),@product_code,@version,@file_name,@file_data,getdate())";
                System.Data.SqlClient.SqlParameter[] pars = new System.Data.SqlClient.SqlParameter[4];
                pars[0] = new System.Data.SqlClient.SqlParameter("@product_code", ProductCode);
                pars[1] = new System.Data.SqlClient.SqlParameter("@version", Version);
                pars[2] = new System.Data.SqlClient.SqlParameter("@file_name", FileName);
                pars[3] = new System.Data.SqlClient.SqlParameter("@file_data",SqlDbType.Image);
                pars[3].Value = FileData;
                if (databaseMan.ExecuteNonQuery(sql, pars) > 0)
                    result = true;
            }
            return result;
        }


        /// <summary>
        /// 得到要升级的文件后缀名
        /// </summary>
        /// <returns></returns>
        public List<FileExtensionDataContract> GetFileExtensionList()
        {
            List<FileExtensionDataContract> result = new List<FileExtensionDataContract>();
            string sql = "select * from FileExtension";
            sql = string.Format(sql);
            DataSet ds = this.databaseMan.ExecuteDataSet(sql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    FileExtensionDataContract FileExtension = new FileExtensionDataContract();
                    FileExtension.ExtensionName = row["ExtensionName"].ToString();
                    result.Add(FileExtension);
                }
            }
            return result;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProductCode"></param>
        /// <param name="Version"></param>
        /// <param name="FileData"></param>
        /// <returns></returns>
        public bool UpFile(DataRow row,string ProductCode, string version)
        {
            bool result = false;
            //删除相同的文件
            string sql = "delete version_file where  FILE_NAME = @FILE_NAME and VERSION = @VERSION and product_code = @product_code";
            System.Data.SqlClient.SqlParameter[] pars1 = new System.Data.SqlClient.SqlParameter[]
            {
                new System.Data.SqlClient.SqlParameter("@FILE_NAME",row["FileName"]),
                new System.Data.SqlClient.SqlParameter("@VERSION",version),
                new System.Data.SqlClient.SqlParameter("@product_code",ProductCode)
            };
            databaseMan.ExecuteNonQuery(sql,pars1);

            //更新版本号
            sql = "update sd_version set version = @version where product_code = @product_code";
            System.Data.SqlClient.SqlParameter[] pars2 = new System.Data.SqlClient.SqlParameter[]
            {
                new System.Data.SqlClient.SqlParameter("@version",version),
                new System.Data.SqlClient.SqlParameter("@product_code",ProductCode)
            };
            if (databaseMan.ExecuteNonQuery(sql,pars2) > 0)
            {
                //插入文件
                sql = "insert into version_file(obj_no,product_code,version,file_name,file_path,file_data,obj_date) " +
                    "values(newid(),@product_code,@version,@file_name,@file_path,@file_data,getdate())";
                System.Data.SqlClient.SqlParameter[] pars = new System.Data.SqlClient.SqlParameter[5];
                pars[0] = new System.Data.SqlClient.SqlParameter("@product_code", ProductCode);
                pars[1] = new System.Data.SqlClient.SqlParameter("@version", version);
                pars[2] = new System.Data.SqlClient.SqlParameter("@file_name", row["filename"]);
                pars[3] = new System.Data.SqlClient.SqlParameter("@file_path", row["filepath"]);
                pars[4] = new System.Data.SqlClient.SqlParameter("@file_data", SqlDbType.Image);
                pars[4].Value = row["fileByte"];
                if (databaseMan.ExecuteNonQuery(sql, pars) > 0)
                    result = true;
            }
            return result;
        }
    }
}
