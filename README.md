# TASK:

1. Необходимо создать некоторых пользователей:
* Candidate – тот, кто находится в поиске работы:
    + id (Guid),
    + имя,
    + фамилия,
    + желаемая должность,
    + краткое описания должности,
    + желаемая заработная плата.
* Employee – тот, который занимает какую-то определенную должность в какой – либо компании:
    + id (Guid),
    + имя,
    + фамилия,
    + должность,
    + краткое описания должности,
    + заработная плата,
    + Компания, в которой работает (страна, город и физический адрес).
2. Создать и реализовать интерфейс, который будет содержать метод, выводящий в консоли данные о пользователе:   
Пример:  
***“Hello, I am {FullName} I want to be a {JobTittle} ({JobDescription}) with a salary from {JobSalary}”***  
***“Hello, I am {FullName}, {JobTittle} in {CompanyName} ({CompanyCountry}, {CompanyCity}, {Company Street}) and my salary {JobSalary}“***  
3. Реализовать создание рандомного количество Candidate и Employee.  
4. Заполнить все данные о пользователях и компании используя библиотеку [Bogus](https://github.com/bchavez/Bogus)  
5. Создать класс UserFactory, который в зависимости от типа пользователя (Employee, Candidate) будет возвращать необходимый объект.
6. Создать интерфейс IReportGenerator.
7. Добавить класс EmployeeReportGenerator, который отсортирует всех работников по компании и по убыванию зп.  
***Вывод : UserId || Company Name || Users Full Name || Salary***  
8. Добавить класс СandidateReportGenerator, который отсортирует всех кандидатов по позиции по возрастанию зп.  
***Вывод : UserId || Users Full Name || JobTittle || Salary***  
[Пример](https://cloud.mail.ru/public/S4UZ/PTQNrZvXJ)
