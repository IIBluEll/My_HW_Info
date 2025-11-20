namespace MyHwInfo.CodeBase.MVP
{
    public abstract class AView : UserControl
    {
        public virtual void Open()
        {
            Visible = true;
        }

        public virtual void Close()
        {
            Visible = false;
        }

        public virtual void Clear()
        {
            // 자식 View에서 초기화 필요 시 override
        }
    }
}
