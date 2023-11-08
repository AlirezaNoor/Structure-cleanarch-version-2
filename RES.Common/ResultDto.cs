namespace RES.Commom;

public class ResultDto
{
    public bool Issuccess { get; set; }
    public string Massegas { get; set; }
}

public class ResultDto<T>
{
    public bool Issuccess { get; set; }
    public string Massegas { get; set; }
    public T Data { get; set; }
}