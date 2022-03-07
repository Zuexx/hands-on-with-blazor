namespace HandsOnWithBlazor.Domain
{
    public class AuditActivity
    {
        public Guid Id { get; set; }                    /*Log id*/
        public DateTime AuditDateTimeUtc { get; set; }  /*Log time*/
        public string? AuditSourceContext { get; set; }  /*Source Context*/
        public string? AuditDescription { get; set; }    /*Description*/
        public string? AuditType { get; set; }           /*Create, Update or Delete*/
        public string? AuditUser { get; set; }           /*Log User*/
        public string? TableName { get; set; }           /*Table where rows been 
                                                          created/updated/deleted*/
        public string? KeyValues { get; set; }           /*Table Pk and it's values*/
        public string? OldValues { get; set; }           /*Changed column name and old value*/
        public string? NewValues { get; set; }           /*Changed column name 
                                                          and current value*/
        public string? ChangedColumns { get; set; }      /*Changed column names*/
    }
}