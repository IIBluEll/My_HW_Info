namespace MyHwInfo.CodeBase.MVP
{
    public abstract class APresenter : IDisposable
    {
        public abstract void Open();
        public abstract void Close();
        public abstract void Dispose();
    }
}
