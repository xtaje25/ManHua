using Qiniu.IO.Model;
using Qiniu.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ManHuaAdmin.Utility
{
    public class QN
    {
#if DEBUG
        public const string IMGSRC = "http://7xiyf4.com1.z0.glb.clouddn.com";
        private const string AK = "ABIJNSgcg6vGrFBUvkwnk8GMinp9vHSSaDlGMrrt";
        private const string SK = "ckurM2tEcJaUafpCrleFMNdCGRMiR8sJenCpoq9v";
        public const string BUCKET = "zm123";
#else
        public const string IMGSRC = "http://7xiyf4.com1.z0.glb.clouddn.com";
        private const string AK = "ABIJNSgcg6vGrFBUvkwnk8GMinp9vHSSaDlGMrrt";
        private const string SK = "ckurM2tEcJaUafpCrleFMNdCGRMiR8sJenCpoq9v";
        public const string BUCKET = "zm123";
#endif

        /// <summary>
        /// 获取七牛上传凭证
        /// </summary>
        /// <param name="bucket">七牛空间</param>
        /// <param name="seconds">凭证有效时长</param>
        public static string GetUploadToken(string bucket, int seconds = 600)
        {
            // 上传策略
            PutPolicy putPolicy = new PutPolicy();
            putPolicy.MimeLimit = "image/*"; // 表示只允许上传图片类型
            // 设置要上传的目标空间
            putPolicy.Scope = bucket;
            // 上传策略的过期时间(单位:秒)
            putPolicy.SetExpires(seconds);

            Mac mac = new Mac(AK, SK);

            return Auth.CreateUploadToken(mac, putPolicy.ToJsonString());
        }
    }
}