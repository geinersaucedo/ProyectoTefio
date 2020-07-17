using System;
using System.Collections.Generic;
using System.Text;

namespace Tefio.Core.Utilitario
{
    public static class ResultTable
    {
        public const string RESULT_CODE_OK = "0";
        public const string RESULT_CODE_ERROR = "1";
        public const string RESULT_CODE_WARNING = "2";

        public const string RESULT_OK_CODE = "0";
        public const string RESULT_OK_MSG = "_result_ok";

        public const string RESULT_ERR_GENERIC_CODE = "1000";
        public const string RESULT_ERR_GENERIC_MSG = "_result_error";

        public const string RESULT_ERR_UNKNOWN_CODE = "9000";
        public const string RESULT_ERR_UNKNOWN_MSG = "_result_error_unknown";

        public const string RESULT_ERR_MODELINVALID_CODE = "1001";
        public const string RESULT_ERR_MODELINVALID_MSG = "_result_error_model_invalid";

        public const string RESULT_ERR_CREATEINVALID_CODE = "1010";
        public const string RESULT_ERR_CREATEINVALID_MSG = "_result_error_create_invalid";

        public const string RESULT_ERR_EDITINVALID_CODE = "1011";
        public const string RESULT_ERR_EDITINVALID_MSG = "_result_error_edit_invalid";

        public const string RESULT_ERR_DELETEINVALID_CODE = "1012";
        public const string RESULT_ERR_DELETEINVALID_MSG = "_result_error_delete_invalid";

        public const string RESULT_ERR_IDNOTFOUND_CODE = "1013";

        #region LOGIN = ERRORES 1100- 1199

        public const string RESULT_ERR_LOGIN_INCORRECT_USER_CODE = "1100";

        #endregion


        #region CATEGORIAS = ERRORES 1200- 1299

        public const string RESULT_ERR_CATEGORIAS_NO_CATEGORIAS_CODE = "1200";

        #endregion


        #region PRODUCTOS = ERRORES 1300- 1399

        public const string RESULT_ERR_PRODUCTOS_SIN_PRODUCTOS_CODE = "1300";
        public const string RESULT_ERR_PRODUCTOS_NO_ENCONTRADOS_CODE = "1301";

        #endregion
    }
}
