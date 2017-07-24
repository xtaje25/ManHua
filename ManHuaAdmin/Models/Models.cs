using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManHuaAdmin.Models
{
    public class Models { }

    #region 文章
    public class AC_Article
    {
        public int ArticleId { get; set; }

        [Required]
        [StringLength(80)]
        public string Title { get; set; }

        [StringLength(50)]
        public string ShortTitle { get; set; }

        [StringLength(50)]
        public string Author { get; set; }

        [StringLength(50)]
        public string Source { get; set; }

        [StringLength(500)]
        public string SourceURL { get; set; }

        public int? SourceType { get; set; }

        [StringLength(50)]
        public string Editor { get; set; }

        public DateTime? PublishDateTime { get; set; }

        public int? RecommandType { get; set; }

        public int? ZoneId { get; set; }

        public bool? IsEableComment { get; set; }

        public bool? IsPublish { get; set; }

        [StringLength(100)]
        public string Tags { get; set; }

        [StringLength(256)]
        public string PicUrl { get; set; }

        public bool IsEnable { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime LastUpdateDateTime { get; set; }

        [Required]
        [StringLength(50)]
        public string LastUpdateEditor { get; set; }

        public int? ImageId { get; set; }

        [StringLength(256)]
        public string RelationType { get; set; }

        [StringLength(256)]
        public string RelationId { get; set; }

        public int DealerId { get; set; }

        public int InfoId { get; set; }

        [StringLength(100)]
        public string Keywords { get; set; }

        [StringLength(100)]
        public string PreKeywords { get; set; }

        public int? WeekClickCount { get; set; }

        public int? MonthClickCount { get; set; }

        public int CommentCount { get; set; }

        public int? ClickCount { get; set; }

        public int pcClickCount { get; set; }

        public int mClickCount { get; set; }

        public int androidClickCount { get; set; }

        public int iosClickCount { get; set; }

        public bool IsPreview { get; set; }

        public int Depth { get; set; }

        public int IsAuditing { get; set; }

        public bool IsRed { get; set; }

        public bool IsTrainee { get; set; }

        public int PraiseCount { get; set; }

        public int ShareCount { get; set; }

        public bool IsShowLable { get; set; }

        public bool IsShowCategory { get; set; }

        public int StatisticLevel { get; set; }

        public int? EditorId { get; set; }

        public int? ArticleType { get; set; }

        public int WX_PV { get; set; }

        public int WX_IP { get; set; }

        public int WX_UV { get; set; }

        public bool IsSoonPublish { get; set; }

        public int apv { get; set; }

        public int spv { get; set; }

        public bool IsKeyWord { get; set; }

        public bool IsDealerArticle { get; set; }
    }
    #endregion

    #region 分页
    public class PageCriteria
    {
        private string _TableName;
        public string TableName
        {
            get { return _TableName; }
            set { _TableName = value; }
        }
        private string _Fileds = "*";
        public string Fields
        {
            get { return _Fileds; }
            set { _Fileds = value; }
        }
        private string _PrimaryKey = "ID";
        public string PrimaryKey
        {
            get { return _PrimaryKey; }
            set { _PrimaryKey = value; }
        }
        private int _PageSize = 10;
        public int PageSize
        {
            get { return _PageSize; }
            set { _PageSize = value; }
        }
        private int _CurrentPage = 1;
        public int CurrentPage
        {
            get { return _CurrentPage; }
            set { _CurrentPage = value; }
        }
        private string _Sort = string.Empty;
        public string Sort
        {
            get { return _Sort; }
            set { _Sort = value; }
        }
        private string _Condition = string.Empty;
        public string Condition
        {
            get { return _Condition; }
            set { _Condition = value; }
        }
        private int _RecordCount;
        public int RecordCount
        {
            get { return _RecordCount; }
            set { _RecordCount = value; }
        }
    }
    #endregion

    #region mh
    public class Tab_Auth_Menu_Relation
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int F_AuthId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int F_MenuId { get; set; }
    }

    public class Tab_Authorization
    {
        [Key]
        public int F_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string F_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string F_AuthType { get; set; }

        public DateTime F_CreateDate { get; set; }
    }

    public class Tab_Menu
    {
        [Key]
        public int F_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string F_Name { get; set; }

        [Required]
        [StringLength(500)]
        public string F_URL { get; set; }

        public int F_ParentId { get; set; }

        public int F_Site { get; set; }
    }

    public class Tab_Role
    {
        [Key]
        public int F_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string F_Name { get; set; }
    }

    public class Tab_Role_Auth_Relation
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int F_RoleId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int F_AuthId { get; set; }
    }

    public class Tab_User
    {
        [Key]
        public int F_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string F_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string F_Password { get; set; }

        public DateTime F_CreateDate { get; set; }
    }

    public class Tab_User_Auth_Relation
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int F_UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int F_RoleId { get; set; }
    }
    #endregion

}