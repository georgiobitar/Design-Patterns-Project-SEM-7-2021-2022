using Infrastructure.Model.enums;

namespace WebAPI.Handlers
{
    public abstract class LoginHandler<T> : IHandler<T> where T : class
    {
        private IHandler<T> Next { get; set; }
        private IHandler<T> Before { get; set; }
        private NextPageStatus status;
        public virtual void Handle(T request)
        {
            Next?.Handle(request);
        }

        public IHandler<T> SetNext(IHandler<T> next)
        {
            Next = next;
            Next?.SetBefore(this);
            return Next;
        }

        public IHandler<T> SetBefore(IHandler<T> before)
        {
            Before = before;
            return Before;
        }

        public IHandler<T> GetBefore()
        {
            return Before;
        }

        public NextPageStatus Status
        {
            get { return status; }
            set { status = value; }
        }
    }

    public interface IHandler<T> where T : class
    {
        IHandler<T> SetNext(IHandler<T> next);
        IHandler<T> SetBefore(IHandler<T> before);
        IHandler<T> GetBefore();
        void Handle(T request);
    }
}
