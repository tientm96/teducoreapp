using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TeduCoreApp.Infrastructure.Interfaces
{
    /*
    * -Repository: là tầng access layer ở giữa, nhiệm vụ connect đến db và toàn bộ những thao tác thông qua Repository.
       +dùng trong pr Data: các interface đã đc tạo ở IRepository ở Data, dùng để xây dựng các thuộc tính chung của thực thể.
       +dùng trong pr Infrastructure: là Repository của toàn bộ, định nghĩa các phương thức để
       làm việc với db.
    */

    //Vì làm việc trên nhiều kiểu entity và nhiều kiểu Key nên ta dùng Generic.
    //với <T,K>: T là kiểu entity đang làm việc, K là kiểu Key ta đang làm việc.

    public interface IRepository<T, K> where T : class // where... nghĩa: chỉ định ra T là class
    {
        //K là kiểu key đang làm việc, params là danh sách các tham số, truyền bao nhiêu tham số đều đc.
        T FindById(K id, params Expression<Func<T, object>>[] includeProperties);

        T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        void Add(T entity);

        void Update(T entity);

        void Remove(T entity);

        void Remove(K id);

        //Xóa theo list entity
        void RemoveMultiple(List<T> entities);
    }
}