# Разработка приложения на тему: Расписание для Вуза
## Работу выполнили:
## Конькова Алин - Дизайнер 🌟
## Цветков Денис - Front-end 🖥️
## Солянов Даниил - Back-end 💣
## Саморокин Иван - разработка БД 🧨
## Жубя Даниил - Тестировщик ⚔️

### БД не работает, приложение не будет работать 😕

#### Тестовые данные для преподавателя: логин: rinat; пароль: 1


#include <stdio.h>

int max_fun(int x, int y, int *res_a, int *res_b);

int main(){
    int a,b;
    int scan;
    int res_a = 0;
    int res_b = 0;

    scan = scanf("%d %d", &a, &b);

    if(scan != 2){
        printf("n/a");
        return 1;
    }
    else {
       int result = max_fun(a,b, &res_a, &res_b);
       printf("%d", result);
    }
    return 0;
}

int max_fun(int x, int y, int *res_a, int *res_b){
    
    for (int i = 1; i < x; i++)
    {
     if(x% i == 0){
        *res_a = i;
     }   
    }
    for (int j = 1; j < y; j++)
    {
        if(y % j == 0){
            *res_b = j;
        }
    }

    if(*res_a>*res_b){
        return *res_a;
    }
    else{
        return *res_b;
    }


        
}
