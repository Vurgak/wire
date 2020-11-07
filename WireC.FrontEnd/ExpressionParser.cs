﻿using WireC.AST;
using WireC.AST.Expressions;
using WireC.Common;

namespace WireC.FrontEnd
{
    public class ExpressionParser
    {
        public static IExpression ParseExpression(ParserState state) =>
            ParsePostfixOperation(state);

        private static IExpression ParsePostfixOperation(ParserState state)
        {
            var operand = ParsePrimaryExpression(state);
            if (state.Consume(TokenKind.LeftParenthesis)) return ParseFunctionCall(state, operand);
            return operand;
        }

        private static IExpression ParseFunctionCall(ParserState state, IExpression callee)
        {
            state.ConsumeOrError(TokenKind.RightParenthesis);
            var span = SourceSpan.Merge(callee.Span, state.Previous().Span);
            return new FunctionCall(span, callee);
        }

        private static IExpression ParsePrimaryExpression(ParserState state)
        {
            if (state.Consume(TokenKind.Identifier)) return new Identifier(state.Previous());
            if (state.Consume(TokenKind.Integer)) return new IntegerLiteral(state.Previous());
            throw new ParseException(
                state.Current().Span,
                $"expected primary expression, but found \"{state.Current().Lexeme}\""
            );
        }
    }
}
