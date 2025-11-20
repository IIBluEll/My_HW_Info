using System.Reflection;

namespace MyHwInfo.CodeBase.Provider
{
    public abstract class ASingleton<T> where T : class
    {
        private static T s_instance;

        public static T Instance
        {
            get
            {
                if(s_instance == null)
                {
                    s_instance = CreateInstance();
                }

                return s_instance;
            }
        }

        protected ASingleton() { }

        private static T CreateInstance()
        {
            ConstructorInfo tCtor = typeof(T).GetConstructor(
                BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                Type.EmptyTypes,
                null);

            if ( tCtor == null )
            {
                throw new InvalidOperationException(
                    $"{typeof(T).Name} 에 private 매개변수 없는 생성자가 필요합니다.");
            }

            return (T)tCtor.Invoke(null);
        }
    }
}
