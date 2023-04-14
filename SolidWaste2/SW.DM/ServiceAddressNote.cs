﻿namespace SW.DM;

public class ServiceAddressNote
{
    public int Id { get; set; }
    public int ServiceAddressId { get; set; }
    public string Note { get; set; }
    public bool DeleteFlag { get; set; }
    public DateTime AddDateTime { get; set; }
    public string AddToi { get; set; }
    public DateTime? ChgDateTime { get; set; }
    public string ChgToi { get; set; }
    public DateTime? DelDateTime { get; set; }
    public string DelToi { get; set; }

    public virtual ServiceAddress ServiceAddress { get; set; }
}
