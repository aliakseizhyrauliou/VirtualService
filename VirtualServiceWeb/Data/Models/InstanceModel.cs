namespace VirtualServiceWeb.Data.Models;

public class InstanceModel : BaseModel
{

    public string InstanceName { get; set; } 

    public DateTime Date { get; set; }

    public string OperationSystem { get; set; } 

    public string UserId { get; set; }
    
    public float Ram { get; set; }
    
    public int CoreCount { get; set; }
    
    public string TemplateId { get; set; }
}