   M S B A M L   `   `   `  ����K  GStankoServiceApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:StankoServiceApp.WindowsStankoServiceApp.Windows  5   	   -    'StankoServiceApp.Windows.ShowTaskWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:StankoServiceApp.Windows     5   	   j fDevExpress.Xpf.LayoutControl.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  5   	   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5   	   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5	   	   f bDevExpress.Xpf.Grid.v17.1.Core, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5
   	   -   5        &   DevExpress.Xpf.Core.ThemeManager    	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$  Office2010Blue 5   	    � Title$= 7Подробная информация о задаче��5      $	��450��5   	   $
��1000��6    � SizeToContent$ WidthAndHeight=�6#    � WindowStartupLocation$ CenterScreen=�6Y   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   6.   �� 5      -   5         ��Name$ column��5      $
��auto �6/   6>   �� 5      $
��auto �6   6.   .+�5   
   +  %DevExpress.Xpf.LayoutControl.GroupBox  4  .DevExpress.Xpf.Core.HeaderedContentControlBase   Header$* $Информация о задаче��6   
�������$��0��6H   $��0��6X   ,  &DevExpress.Xpf.Core.ContentControlBase   Content. 5      0  *DevExpress.Xpf.LayoutControl.LayoutControl  .  (DevExpress.Xpf.LayoutControl.LayoutGroup	   Orientation$	 Vertical=�6!   .+�5      -  'DevExpress.Xpf.LayoutControl.LayoutItem  
   Label$
 Наименование��6"      
IsRequired .    Content. 5      �� -   5         ��Name$ 
tbNameTask��5       $	��300��64   5        5       $
 Проект��6"    . . 5!      �� -   5        $ 	tbProject��5!       5"        5$      $
 Сроки до��6"    . . 5%      �� -   5        $ 	tbEndDate��5%       5&        5(      $
 Приоритет��6"    . . 5)      ��  �� Orientation$ 
Horizontal=�6!   .+�5*      �� -   5         ��Name$ imgIconPriority��5*   A    �� EdgeMode$ Aliased=�6    $��20��6Z   $��20��6e   $��0 0 5 0q�6q   $��Center=�6�   �� 5+      -   5        $ 
tbPriority��5+   $   $��Center=�68   5,      5-        5/      -   5          Name$ liStatus��5/   "   $
 Статус��64    . . 50      �� $ 
Horizontal=�6!   .+�51      �� -	   5        $ imgIconStatus��51   A   $ Aliased=�6    $��20��6X   $��20��6c   $��0 0 5 0q�6o   $��Center=�6�   �� 52      -
   5        $ tbStatus��52   $   $��Center=�66   53      54        56      -   5        $ liCompletionDate��56   "   $
 Завершена��6<    . . 57      �� -   5        $ tbCompletionDate��57       58        5:      $
 Описание��6"    . . 5;      %	  DevExpress.Xpf.Editors.MemoEdit	  -   5         	 Name$ tbDescription��5;   #   %
  DevExpress.Xpf.Editors.BaseEdit 
  
IsReadOnly . 6:   5<      5>      5?        5A   
   -   5          Name$ gbWorker��5A      $ Исполнитель��6*   
�������$��1��6R   $��0��6b   . 5B        -   5          Name$ lcWorker��5B   !   .+�5C        $	��150��6"   $
��Left=�61   . 5D      �� -   5        $ imgPhoto��5D   k   $ Aliased=�6    �� BitmapScalingMode$ HighQuality=�6=   $	��150��6}   $	��150��6�   5E        5G      $	 Vertical=�6#   .+�5H        $
 ФИО:��6&    . . 5I      �� -   5        $ tbFIO��5I   $   5J        5L      $
 Дата рожд:��6&    . . 5M      �� -   5        $ tbDateOfBirth��5M   $   5N        5P      $
 Телефон:��6&    . . 5Q      �� -   5        $ tbPhone��5Q   $   5R        5T      $
 Работает с:��6&    . . 5U      �� -   5        $ tbDateOfEmploy��5U   $   5V        5X      $
 Должность:��6&    . . 5Y      �� -   5        $ 
tbPosition��5Y   $   5Z        5\      $
 E-mail:��6&    . . 5]      �� -   5        $ tbEmail��5]   $   5^      5_      5`      5a        5c   
   -   5        $ 	gbManager��5c      $ Менеджер��6+   
�������$��2��6P   $��0��6`   . 5e        -   5        $ 	lcManager��5e   !   .+�5f        $	��150��6"   $
��Left=�61   . 5g      �� -   5        $ 	imgPhotoM��5g      $	��150��60   $	��150��6@   $ Aliased=�6O   $ HighQuality=�6p   5h        5j      $	 Vertical=�6#   .+�5k        $
 ФИО:��6&    . . 5l      �� -   5        $ tbFIOM��5l   $   5m        5o      $
 Дата рожд:��6&    . . 5p      �� -   5        $ tbDateOfBirthM��5p   $   5q        5s      $
 Телефон:��6&    . . 5t      �� -   5        $ tbPhoneM��5t   $   5u        5w      $
 Работает с:��6&    . . 5x      �� -   5        $ tbDateOfEmployM��5x   $   5y        5{      $
 Должность:��6&    . . 5|      �� -   5        $ tbPositionM��5|   $   5}        5      $
 E-mail:��6&    . . 5�      �� -   5        $ tbEmailM��5�   $   5�      5�      5�      5�        5�   
   -    5        $ gbFiles��5�      $# Вложения задачи��6)   
�������$��0��6U   $��1��6e   . 5�      %  DevExpress.Xpf.Grid.GridControl  -!   5          Name$ gcFiles��5�      )  #DevExpress.Xpf.Grid.DataControlBase   AutoGenerateColumns$
 None=�6/      SelectionMode$	 Row=�6J      AllowInitiallyFocusedRow .  |�.    View 5�      #  DevExpress.Xpf.Grid.TableView  5�      -"   5          Name$ tvFiles��5�   $   &   DevExpress.Xpf.Grid.DataViewBase   AllowEditing .     NavigationStyle$	 Row=�6J   &   DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .  6`       Columns.  5�      $  DevExpress.Xpf.Grid.GridColumn  -#   5        !  Name$! 
columnIcon��5�   !   $  DevExpress.Xpf.Grid.ColumnBase"   	FieldName$" TaskFile��65   $  DevExpress.Xpf.Grid.BaseColumn#   Header)  #DevExpress.Xpf.Core.ObjectConverter$# Иконка 6J   $   	SortOrder$$ 	Ascending=�6Z   %   HeaderToolTip$% Иконка файла��6q   &   VisibleIndex$& 0��6�   '   BestFitMode$' AllRows=�6�   (   CellTemplate( 5�      �� 5�      .R�5�      �� $ 
Horizontal=�6)   $��Center=�6B   $��Center=�6_   .+�5�   "   �� $��25��6(   $��25��63   $ Aliased=�6?   $��5 0 5 0q�6�   $��Center=�6�   ��6`   �� *RowData.Row.File.FileIcon+6�   5�      5�      5�        5�      $# Файл 6!   $" File.FileName��6/   $$ 	Ascending=�6I   )   	SortIndex$) 1��6_   $)% #Наименование файла��6m   *   AllowResizing]	 YDevExpress.Data.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5 	 /DevExpress.Utils.Design.DefaultBooleanConverter$
* True 6�   +   AllowMoving$
+ True 6�   ,   AutoFilterCondition$, Contains=�6�   $& 1��6�     5�      -$   5        $! 
columnDate��5�   !   $# Дата 65   $" File.ChangeDate��6C   $$ 	Ascending=�6_   $) 2��6u   $A% ;Пользователь, изменивший статус��6�   $
* True 6�   $
+ True 6�   $, Contains=�6�   $& 2��6�     5�      -%   5        $! columnDownload��5�   !   $# Скачать 6:   $$ 	Ascending=�6K   $% Иконка файла��6b   $& 3��6   $' AllRows=�6�   ( 5�      �� 5�      .R�5�      �� $ 
Horizontal=�6)   $��Center=�6B   $��Center=�6_   .+�5�   "   �� -&   5        $��25��5�   (   $��25��63   $ Aliased=�6?   $��5 0 5 0q�6`   $��Center=�6q   $<��6/StankoServiceApp;component/Resources/SaveTo_32x32.png��6�   6�   5�      5�      5�      5�      5�        5�   
   -'   5        $ 	gbHistory��5�      $E ?История изменения статусов задачи��6+   
�������$��2��6i   $��1��6}   $��1��6�   . 5�        -(   5        $ 	gcHistory��5�      $
 None=�61   $
 None=�6L    .  |�.   5�        5�      -)   5        $ 	tvHistory��5�   ;    .   .  $
 None=�6c   .  5�        $# Кто изменил 6!   $" FullName��66   $$ 	Ascending=�6K   $) 0��6a   $A% ;Пользователь, изменивший статус��6o   $
* True 6�   $
+ True 6�   $, Contains=�6�   $& 0��6�     5�      $# Дата и время 6!   $" DateTime��67   $$ 	Ascending=�6L   $) 1��6b   $/% )Дата и время изменения��6p   $
* True 6�   $
+ True 6�   $, Contains=�6�   $& 1��6�   -   EditSettings- 5�      6  0DevExpress.Xpf.Editors.Settings.DateEditSettings  5�      6  0DevExpress.Xpf.Editors.Settings.BaseEditSettings.   DisplayFormat$. dd-MM-yyyy HH:mm:ss��6/   5�        5�      $# Комментарий 6!   $" Comment��66   $$ 	Ascending=�6J   $) 2��6`   $3% -Оставленный комментарий��6n   $
* True 6�   $
+ True 6�   $, Contains=�6�     5�      -*   5        $! columnStatus��5�   <   $&#  Изменил статус на 6!   $" HistoryTask��6R   $$ 	Ascending=�6j   $) 3��6�   $5% /Статус на который изменил��6�   /   AllowAutoFilter/ .  $& 2��6�   ( 5�      �� 5�      .R�5�      �� $ 
Horizontal=�6)   $
��Left=�6B   $��Center=�6]   .+�5�   "   �� $ Aliased=�6(   $��20��6I   $��20��6T   $��5 0 5 0q�6�   $��Center=�6�   ��6`   �� *RowData.Row.StatusIcon+6�   �� 5�   "   $��Center=�6\   ��6-   �� *RowData.Row.StatusTaskHistory+6\   5�      5�      5�      5�      5�      5�      5�      