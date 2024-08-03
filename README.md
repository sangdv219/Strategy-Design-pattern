Trong Strategy Pattern, chúng ta tách các thuật toán (hay chiến lược) ra khỏi lớp chính và đặt chúng vào các lớp riêng biệt để dễ dàng thay đổi và mở rộng.
Interface IPromoteStrategy: Định nghĩa phương thức DoDiscount mà tất cả các chiến lược giảm giá phải triển khai.
Các lớp NoDiscountStrategy, QuarterDiscountStrategy, và HalfDiscountStrategy: Triển khai các chiến lược giảm giá khác nhau dựa trên interface IPromoteStrategy.
Lớp Ticket: Chứa một tham chiếu đến IPromoteStrategy và sử dụng nó để áp dụng chiến lược giảm giá hiện tại. Bạn có thể thay đổi chiến lược giảm giá của một Ticket bất kỳ lúc nào thông qua phương thức SetPromoteStrategy.
Lớp Program: Tạo ra các đối tượng Ticket và áp dụng các chiến lược giảm giá ngẫu nhiên.
Tất cả các thành phần này cùng nhau thể hiện Strategy Design Pattern, cho phép dễ dàng thay đổi thuật toán giảm giá mà không cần phải thay đổi mã nguồn của lớp Ticket. 
Điều này giúp mã nguồn dễ bảo trì và mở rộng hơn.
