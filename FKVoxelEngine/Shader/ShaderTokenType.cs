//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170710
// Desc:    
//-------------------------------------------------
namespace FKVoxelEngine
{
    public enum ENUM_ShaderTokenType
    {
        EOF,
        UNDEFINED,
        PREPROCESSOR,
        KEYWORD,
        KEYWORD_FX,
        KEYWORD_SPECIAL,
        TYPE,
        IDENTIFIER,
        INTRINSIC,
        COMMENT_LINE,
        COMMENT,
        NUMBER,
        FLOAT,
        STRING_LITERAL,
        OPERATOR,
        DELIMITER,
        LEFT_BRACKET,
        RIGHT_BRACKET,
        LEFT_PARENTHESIS,
        RIGHT_PARENTHESIS,
        LEFT_SQUARE_BRACKET,
        RIGHT_SQUARE_BRACKET
    }
}
