   M S B A M L   `   `   `  ����C  ?practice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:practice.Pagespractice.Pages  5           practice.Pages.CarSalePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:practice.Pages     5      -   5          N� Title$  CarSalePage��5	      .��5      � ���#FFF � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Right=�6.   $��0��6J   .+�5      �� $+��%Найти по автомобилю:��6   $��15q�64   �� 5      -   5         ��Name$ findtext��5      $��5q�6)   $��20��64   $	��150��6@   �� 5      -   5         ��Name$ findBtn��5      $��
Найти��6&   $��5q�66   $��20��6A   $	��150��6M   6Y   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	CarSaleDG��5      $��Stretch=�6&      AutoGenerateColumns .     
IsReadOnly . $��1��6r      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Документ��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 67   �� *salesDocument+  5      $	 Дата��6%   
 63   �� *
dataOfSale+ �� StringFormat$ {0:dd.MM.yyyy}��  5      $-	 'Документ поступления��6%   
 6C   �� *receiptDocument+  5      $	 Автомобиль��6%   
 69   �� *	nameCar+  5      $	 ФИО менеджера��6%   
 6<   �� *fiiNameEmployee+  5      $	 Цена��6%   
 63   �� *price+4  .System.Windows.Controls.DataGridTemplateColumn  5         CellTemplate 5      �� 5       .R�5!      �� -   5        $��Изменить��5!   %   $��5q�68   $��30��6C   $	��150��6O   6[   5"      5$      5&      �� 5'   
   $ 
Horizontal=�6   $��2��6.   .+�5(      �� -   5        $ AddBtn��5(      $��Добавить��6%   $��5q�68   $��30��6C   $	��150��6O   6[   �� 5)      -   5        $ DelBtn��5)      $��Удалить��6%   $��5q�67   $��30��6B   $	��150��6N   6Z   �� 5*      -   5        $ UpdBtn��5*      $��Обновить��6%   $��5q�68   $��30��6C   $	��150��6O   6[   �� 5+      -	   5        $ backBtn��5+      $��
Назад��6&   $��5q�66   $��30��6A   $	��150��6M   6Y   5,      5-      5.      