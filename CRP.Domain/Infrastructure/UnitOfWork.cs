namespace CRP.Domain.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRepository _repository;

        public UnitOfWork(IRepository repository)
        {
            _repository = repository;
        }

        public IRepository Repository
        {
            get { return _repository; }
        }

        public void CommitChanges()
        {
            _repository.CommitChanges();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }


    }
}
