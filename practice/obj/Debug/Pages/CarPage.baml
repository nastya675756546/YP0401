   M S B A M L   `   `   `  ����C  ?practice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:practice.Pagespractice.Pages  5          practice.Pages.CarPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:practice.Pages     5      -   5          N� Title$  CarPage��5	      .��5      � ���#FFF � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Right=�6.   $��0��6J   .+�5      �� $#��Фильтр по цвету:��6   $��15q�60   �� 5      -   5         ��Name$ 	filtrtext��5      $��5q�6*   $��20��65   $	��150��6A   �� 5      -   5         ��Name$ filtrBtn��5      $��
Найти��6'   $��5q�67   $��20��6B   $	��150��6N   6Z   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ CarDG��5      $��Stretch=�6"      AutoGenerateColumns .     
IsReadOnly . $��1��6n      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Наименование��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6;   �� *	nameCar+  5      $		 VIN��6%   
 62   �� *VIN+  5      $	 
Марка��6%   
 64   �� *stamp+  5      $	 Модель��6%   
 65   �� *model+  5      $	 Цвет��6%   
 63   �� *color+4  .System.Windows.Controls.DataGridTemplateColumn  5         CellTemplate 5      �� 5      .R�5       �� -   5        $��Изменить��5    %   $��5q�68   $��30��6C   $	��150��6O   6[   5!      5#      5%      �� 5&   
   $ 
Horizontal=�6   $��2��6.   .+�5'      �� -   5        $ AddBtn��5'      $��Добавить��6%   $��5q�68   $��30��6C   $	��150��6O   6[   �� 5(      -   5        $ DelBtn��5(      $��Удалить��6%   $��5q�67   $��30��6B   $	��150��6N   6Z   �� 5)      -   5        $ UpdBtn��5)      $��Обновить��6%   $��5q�68   $��30��6C   $	��150��6O   6[   �� 5*      -	   5        $ backBtn��5*      $��
Назад��6&   $��5q�66   $��30��6A   $	��150��6M   6Y   5+      5,      5-      