   M S B A M L   `   `   `  ����K  GStankoServiceApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:StankoServiceApp.WindowsStankoServiceApp.Windows  5   	   0    *StankoServiceApp.Windows.ShowProjectWindow   5   	   f bDevExpress.Xpf.Grid.v17.1.Core, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   a ]DevExpress.Xpf.Core.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  6I   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:StankoServiceApp.Windows     5   	   j fDevExpress.Xpf.LayoutControl.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  5   	   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5   	   -   5        &   DevExpress.Xpf.Core.ThemeManager    	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$  Office2010Blue 5	   	    � Title$? 9Подробная информация о проекте��5   	   $	��450��60    � WindowStartupLocation$ CenterScreen=�6=   $	��500��6y    � SizeToContent$ WidthAndHeight=�6�   $��Visible=�6�   $��Visible=�6�   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   6/   �� 5      $
��auto �6   6/   .+�5   
   +  %DevExpress.Xpf.LayoutControl.GroupBox  4  .DevExpress.Xpf.Core.HeaderedContentControlBase   Header$, &Информация о проекте��6   
�������$��0��6I   $��0��6Y   ,  &DevExpress.Xpf.Core.ContentControlBase   Content. 5      0  *DevExpress.Xpf.LayoutControl.LayoutControl  .+�5      .  (DevExpress.Xpf.LayoutControl.LayoutGroup     Orientation$ Vertical=�6#   .+�5      -  'DevExpress.Xpf.LayoutControl.LayoutItem  	   Label$	 Название:��6&   
   
IsRequired
 .    Content. 5      �� -   5         ��Name$ tbNameProject��5   $   5        5       $	 Дата начала:��6&   
 . . 5!      �� -   5        $ tbDateStart��5!   $   5"        5$      $	 Сроки до:��6&   
 . . 5%      �� -   5        $ 	tbDateEnd��5%   $   5&        5(      $	 Завершен:��6&   
 . . 5)      �� -   5        $ tbCompletionDate��5)   $   5*        5,      $	 Тип проекта:��6&   
 . . 5-      �� -   5        $ tbTypeProject��5-   $   5.        50      $"	 Статус проекта:��6&   
 . . 51      ��  �� Orientation$ 
Horizontal=�6%   .+�52      �� -   5         ��Name$ imgIcon��52   $   $��0 0 5 0q�65   $��Center=�6F   �� 53      -   5        $ tbStatusProject��53   (   $��Center=�6A   54      55      �� 57      $ 
Horizontal=�6!   $	��Top=�6:   .+�59      �� $��ТЗ проекта:��6$   $��0 0 5 0q�67   $��Center=�6H   $
��Left=�6c   $��Medium"�6~   �� 5:      -	   5        $ imgFile��5:   N   $y�	Collapsed=�6    $��30��67   $��30��6B   $��Center=�6_   6|   �� 5;      -
   5        $ tbDownloadFile��5;   $   
���\\��$%��Файл отсутствует��6S   $��Center=�6k   $��Right=�6�   &	   DevExpress.Xpf.Core.SimpleButton	  5<      -   5         	 Name$ 
sbDownLoad��5<   E   $��Center=�6*   $��10 0 0 0q�6Y   $��Скачать...��6k   $��Right=�6�    	  Glyph 6�   *
  $DevExpress.Xpf.Core.DXImageExtension
   
  Image1  +DevExpress.Xpf.Core.Native.DXImageConverter$ ExportFile_16x16.png 6�   5=      5>      5?      5@        5C   
   -   5          Name$ 	gbManager��5C      $6 0Информация о руководителе��6+   
�������$��1��6a   $��0��6q   . 5D        .+�5E        $	��150��6"   $
��Left=�61   . 5F      �� -   5        $ imgPhoto��5F   k    �� EdgeMode$ Aliased=�6    �� BitmapScalingMode$ HighQuality=�6=   $	��150��6}   $	��150��6�   5G        5I      $ Vertical=�6#   .+�5J        $	 ФИО:��6&   
 . . 5K      �� -   5        $ tbFIO��5K   $   5L        5N      $	 Дата рожд:��6&   
 . . 5O      �� -   5        $ tbDateOfBirth��5O   $   5P        5R      $	 Телефон:��6&   
 . . 5S      �� -   5        $ tbPhone��5S   $   5T        5V      $	 Работает с:��6&   
 . . 5W      �� -   5        $ tbDateOfEmploy��5W   $   5X        5Z      $	 Должность:��6&   
 . . 5[      �� -   5        $ 
tbPosition��5[   $   5\        5^      $	 E-mail:��6&   
 . . 5_      �� -   5        $ tbEmail��5_   $   5`      5a      5b      5c        5f   
   -   5        $ 	gbHistory��5f      $G AИстория изменения статусов проекта��6+   
�������$��2��6j   $��1��6~   . 5h      %  DevExpress.Xpf.Grid.GridControl  -   5          Name$ 	gcHistory��5h      )  #DevExpress.Xpf.Grid.DataControlBase   AutoGenerateColumns$
 None=�61      SelectionMode$
 None=�6L      AllowInitiallyFocusedRow .  |�.     View 5i      #  DevExpress.Xpf.Grid.TableView  5j      &   DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .  &   DevExpress.Xpf.Grid.DataViewBase   AllowEditing .     NavigationStyle$
 None=�6P      Columns. 5m      $  DevExpress.Xpf.Grid.GridColumn  $  DevExpress.Xpf.Grid.BaseColumn   Header)  #DevExpress.Xpf.Core.ObjectConverter$ Кто изменил 6!   $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ FullName��66       	SortOrder$  	Ascending=�6K   !   	SortIndex$! 0��6a   "   HeaderToolTip$A" ;Пользователь, изменивший статус��6o   #   AllowResizing]	 YDevExpress.Data.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5 	 /DevExpress.Utils.Design.DefaultBooleanConverter$
# True 6�   $   AllowMoving$
$ True 6�   %   AutoFilterCondition$% Contains=�6�   &   VisibleIndex$& 0��6�     5n      $ Дата и время 6!   $ DateTime��67   $  	Ascending=�6L   $! 1��6b   $/" )Дата и время изменения��6p   $
# True 6�   $
$ True 6�   $% Contains=�6�   $& 1��6�   '   EditSettings' 5o      6  0DevExpress.Xpf.Editors.Settings.DateEditSettings  5p      6  0DevExpress.Xpf.Editors.Settings.BaseEditSettings(   DisplayFormat$( dd-MM-yyyy HH:mm:ss��6/   5s        5t      $ Комментарий 6!   $ Comment��66   $  	Ascending=�6J   $! 2��6`   $3" -Оставленный комментарий��6n   $
# True 6�   $
$ True 6�   $% Contains=�6�     5v      $&  Изменил статус на 6!   $ HistoryProject��6<   $  	Ascending=�6W   $! 3��6m   $5" /Статус на который изменил��6{   )   AllowAutoFilter) .  $& 2��6�   *   CellTemplate* 5w      �� 5x      .R�5y      �� $ 
Horizontal=�6)   $
��Left=�6B   $��Center=�6]   .+�5z   "   �� $ Aliased=�6(   $��5 0 5 0q�6I   $��Center=�6�   ��6Z   �� *RowData.Row.StatusIcon+6�   �� 5{   "   $��Center=�6^   ��6,   �� *" RowData.Row.StatusProjectHistory+6^   5|      5}      5      5�      5�      5�      5�      