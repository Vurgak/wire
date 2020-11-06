﻿using WireC.AST.Expressions;

namespace WireC.AST
{
    public interface IExpressionVisitor<out T>
    {
        T VisitIdentifier(Identifier identifier);
        T VisitIntegerLiteral(IntegerLiteral integer);
    }
}