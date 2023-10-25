public interface Expression
{
    Expression leftExpression { get; set; }
    Expression rightExpression { get; set; }
    float Evaluate(Context context);
}

public class NumberExpression : Expression {
    private float value;
    public Expression leftExpression { get; set; }
    public Expression rightExpression { get; set; }
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

public class AddExpression : Expression {
    public Expression leftExpression { get; set; }
    public Expression rightExpression { get; set; }
    public AddExpression(Expression leftExpression, Expression rightExpression)
    {
        this.leftExpression = leftExpression;
        this.rightExpression = rightExpression;
    }
    public float Evaluate(Context context)
    {
        return leftExpression.Evaluate(context) + rightExpression.Evaluate(context);
    }
    public override string ToString()
    {
        if (leftExpression == null || rightExpression == null) return " + ";
        return leftExpression.ToString() + " + " + rightExpression.ToString();
    }
}

public class SubtractExpression : Expression
{
    public Expression leftExpression { get; set; }
    public Expression rightExpression { get; set; }
    public SubtractExpression(Expression leftExpression, Expression rightExpression)
    {
        this.leftExpression = leftExpression;
        this.rightExpression = rightExpression;
    }
    public float Evaluate(Context context)
    {
        return leftExpression.Evaluate(context) - rightExpression.Evaluate(context);
    }
    public override string ToString()
    {
        if (leftExpression == null || rightExpression == null) return " + ";
        return leftExpression.ToString() + " - " + rightExpression.ToString();
    }
}

public class MultiplyExpression : Expression
{
    public Expression leftExpression { get; set; }
    public Expression rightExpression { get; set; }
    public MultiplyExpression(Expression leftExpression, Expression rightExpression)
    {
        this.leftExpression = leftExpression;
        this.rightExpression = rightExpression;
    }
    public float Evaluate(Context context)
    {
        return leftExpression.Evaluate(context) * rightExpression.Evaluate(context);
    }
    public override string ToString()
    {
        if (leftExpression == null || rightExpression == null) return " + ";
        return leftExpression.ToString() + " * " + rightExpression.ToString(); ;
    }
}

public class DivideExpression : Expression
{
    public Expression leftExpression { get; set; }
    public Expression rightExpression { get; set; }
    public DivideExpression(Expression leftExpression, Expression rightExpression)
    {
        this.leftExpression = leftExpression;
        this.rightExpression = rightExpression;
    }
    public float Evaluate(Context context)
    {
        return leftExpression.Evaluate(context) / rightExpression.Evaluate(context);
    }
    public override string ToString()
    {
        if (leftExpression == null || rightExpression == null) return " + ";
        return leftExpression.ToString() + " / " + rightExpression.ToString();
    }
}

public class Context {
    //Additional data
}