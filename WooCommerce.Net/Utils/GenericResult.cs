namespace WooCommerce.Net.Utils
{
    public class GenericSimpleResult
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public string Json { get; set; }
    }

    public class GenericResult<TResult> : GenericSimpleResult
    {
        public TResult Result { get; set; }
    }

}
