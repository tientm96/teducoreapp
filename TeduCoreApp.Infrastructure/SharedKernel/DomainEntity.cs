namespace TeduCoreApp.Infrastructure.SharedKernel
{
    //Vì dùng chung cho all, nên dùng abstract class để kế thừa cho dễ.
    //  thực thi Id sẵn luôn, ko cần phải ghi đè như interface.

    public abstract class DomainEntity<T>
    {
        //Phần nào chung thì đặt vào 1 file chung, phần nào riêng thì đặt vào từng file db riêng.

        //Đây là class base dùng để kế thừa lại trong tất cả các class Entity. 
        //Class này chứa các thuộc tính dùng chung.

        //vì class dùng chung nên phải public
        public T Id { get; set; }

        /// <summary>
        /// Transient: tạm thời. Mới tạo ra thì = default(T) nên là true, nhưng khi set Id rồi thì trả về false.
        /// True if domain entity has an identity
        /// </summary>
        /// <returns></returns>
        public bool IsTransient()
        {
            return Id.Equals(default(T));
        }
    }
}