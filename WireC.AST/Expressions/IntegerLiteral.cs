﻿using WireC.Common;

namespace WireC.AST.Expressions
{
    public class IntegerLiteral : IExpression
    {
        public IntegerLiteral(int nodeId, Token token)
        {
            NodeId = nodeId;
            Span = token.Span;
            Token = token;
        }

        public Token Token { get; }

        public int NodeId { get; }

        public SourceSpan Span { get; }

        public T Accept<T>(IExpressionVisitor<T> visitor) => visitor.VisitIntegerLiteral(this);
    }
}