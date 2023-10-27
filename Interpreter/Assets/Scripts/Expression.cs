public interface IExpression
{
    IExpression LeftExpression { get; set; }
    IExpression RightExpression { get; set; }
    float Evaluate(Context context);
}

public class NumberExpression : IExpression {
    private readonly float value;
    public IExpression LeftExpression { get; set; }
    public IExpression RightExpression { get; set; }
    public NumberExpression(float value)
    {
        this.value = value;
    }
    public float Evaluate (Context context)
    {
        return value;
    }
    public override string ToString()
    {
        return value.ToString();
    }
}

public class AddExpression : IExpression {
    public IExpression LeftExpression { get; set; }
    public IExpression RightExpression { get; set; }
    public AddExpression(IExpression leftExpression, IExpression rightExpression)
    {
        this.LeftExpression = leftExpression;
        this.RightExpression = rightExpression;
    }
    public float Evaluate(Context context)
    {
        return LeftExpression.Evaluate(context) + RightExpression.Evaluate(context);
    }
    public override string ToString()
    {
        if (LeftExpression == null || RightExpression == null) return " + ";
        return LeftExpression.ToString() + " + " + RightExpression.ToString();
    }
}

public class SubtractExpression : IExpression
{
    public IExpression LeftExpression { get; set; }
    public IExpression RightExpression { get; set; }
    public SubtractExpression(IExpression leftExpression, IExpression rightExpression)
    {
        this.LeftExpression = leftExpression;
        this.RightExpression = rightExpression;
    }
    public float Evaluate(Context context)
    {
        return LeftExpression.Evaluate(context) - RightExpression.Evaluate(context);
    }
    public override string ToString()
    {
        if (LeftExpression == null || RightExpression == null) return " + ";
        return LeftExpression.ToString() + " - " + RightExpression.ToString();
    }
}

public class MultiplyExpression : IExpression
{
    public IExpression LeftExpression { get; set; }
    public IExpression RightExpression { get; set; }
    public MultiplyExpression(IExpression leftExpression, IExpression rightExpression)
    {
        this.LeftExpression = leftExpression;
        this.RightExpression = rightExpression;
    }
    public float Evaluate(Context context)
    {
        return LeftExpression.Evaluate(context) * RightExpression.Evaluate(context);
    }
    public override string ToString()
    {
        if (LeftExpression == null || RightExpression == null) return " + ";
        return LeftExpression.ToString() + " * " + RightExpression.ToString(); ;
    }
}

public class DivideExpression : IExpression
{
    public IExpression LeftExpression { get; set; }
    public IExpression RightExpression { get; set; }
    public DivideExpression(IExpression leftExpression, IExpression rightExpression)
    {
        this.LeftExpression = leftExpression;
        this.RightExpression = rightExpression;
    }
    public float Evaluate(Context context)
    {
        return LeftExpression.Evaluate(context) / RightExpression.Evaluate(context);
    }
    public override string ToString()
    {
        if (LeftExpression == null || RightExpression == null) return " + ";
        return LeftExpression.ToString() + " / " + RightExpression.ToString();
    }
}

public class Context {
    //Additional data
}