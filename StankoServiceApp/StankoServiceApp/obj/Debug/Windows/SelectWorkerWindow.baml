   M S B A M L   `   `   `  ����K  GStankoServiceApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:StankoServiceApp.WindowsStankoServiceApp.Windows  5   	   1    +StankoServiceApp.Windows.SelectWorkerWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:StankoServiceApp.Windows     5   	   f bDevExpress.Xpf.Grid.v17.1.Core, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5   	   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5   	   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5
   	   Hdxlc9http://schemas.microsoft.com/netfx/2009/xaml/presentation    5   	   c _DevExpress.Xpf.Charts.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxc4http://schemas.devexpress.com/winfx/2008/xaml/charts  5   	   -   5        &   DevExpress.Xpf.Core.ThemeManager    	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$  Office2010Blue 5   	    � Title$+ %Выберите сотрудника��64   $	��650��5   
   $	��800��6   $	��800��6#   $	��800��63    � WindowStartupLocation$ CenterScreen=�6B   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $��* �6   6)   �� 5      $	��200 �6   6+   �� 5      $
��Auto �6   6,    � ColumnDefinitions 5   
   �� 5      6!   �� 5      $
��auto �6   6.   .+�5   
   %  DevExpress.Xpf.Grid.GridControl  -   5          Name$ gcWorker��5      $��2��6,   $��0��6=   )  #DevExpress.Xpf.Grid.DataControlBase   AutoGenerateColumns$
 None=�6M   #   EnableSmartColumnsGeneration .    SelectionMode$	 Row=�6�   	   View	 5      "  DevExpress.Xpf.Grid.CardView  5      -   5        
  Name$
 cvWorker��5      &   DevExpress.Xpf.Grid.DataViewBase   ShowTotalSummary .    
CardLayout$
 Rows=�6I      ShowFilterPanelMode$ 
ShowAlways=�6[      ShowSearchPanelMode$ Always=�6|   &   DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .     ShowFocusedRectangle . 6�      Columns. 5"      $  DevExpress.Xpf.Grid.GridColumn  $	  DevExpress.Xpf.Grid.BaseColumn 	  Header)
  #DevExpress.Xpf.Core.ObjectConverter$ Фото
 6   $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ 	PhotoShow��6+    	  AllowMoving]	 YDevExpress.Data.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5 	 /DevExpress.Utils.Design.DefaultBooleanConverter$
 True 6B      ReadOnly .  	  
FixedWidth .    AllowSearchPanel$ False 6w      EditSettings 5#      7  1DevExpress.Xpf.Editors.Settings.ImageEditSettings  5$      6  0DevExpress.Xpf.Editors.Settings.BaseEditSettings   MaxWidth$	 150Q�6,    �� EdgeMode$ Aliased=�6;    �� BitmapScalingMode$ HighQuality=�6\   5&        5'      $ Имя
 6   $
 Name��6*    . 6;     5(      $ Фамилия
 6   $ Surname��6.    . 6B     5)      $ Отчетсво
 6   $ 
Patronymic��6/   $
 True 6F    . 6Y     5*      $ Дата рожд
 6   $ DateOfBirth��60    . 6H     5+      $ Работает с
 6   $ DateOfEmploy��61    . 6J     5,      $ Телефон
 6   $ Phone��6.      UnboundType8 	 2DevExpress.Utils.Design.UnboundColumnTypeConverter$ DateTime 6@    . 6W     5-      $ Должность
 6   $ Position.PositionName��60    . 6R     5.      $ Эл. адрес
 6   $ 
User.Email��60    . 6G   5/      �� 51   
   -   5         ��Name$ gbTask��51   /   $y�	Collapsed=�6   $6��0Текущие задачи сотрудника��6?   
�������$��2��6u   $��2��6�   .��52        -   5        $ gcTask��52         AllowInitiallyFocusedRow .  $��1��6O   $
 None=�6\    . $
 None=�6�   	 53      #  DevExpress.Xpf.Grid.TableView  54       .  |�.     AllowPerPixelScrolling .  .     AllowEditing  .  !   ShowAutoFilterRow! .  $ Default=�6�   $ Default=�6�   . 57        $ Наименование
 6!   $ TaskName��67   "   	SortOrder$" 	Ascending=�6L   #   	SortIndex$# 0��6b   $ 	  HeaderToolTip$+$ %Наименование задачи��6p   % 	  AllowResizing$
% True 6�   $
 True 6�   &   AutoFilterCondition$& Contains=�6�     58      $ Менеджер
 6!   $ Manager.FullName��63   $" 	Ascending=�6P   $# 1��6f   $-$ 'Наименование проекта��6t   $
% True 6�   $
 True 6�   $& Contains=�6�     59      $ Проект
 6!   $ Project.Name��61   $" 	Ascending=�6J   $# 2��6`   $-$ 'Наименование проекта��6n   $
% True 6�   $
 True 6�   $& Contains=�6�     5:      $ Срок до
 6!   $ EndDate��62   $" 	Ascending=�6F   $# 3��6\   $H$ BСроки завершения работы над задачей��6j   $
% True 6�   $
 True 6�   $& Contains=�6�     5<      $ Статус
 6!   $
 Task��61   $" 	Ascending=�6B   $# 4��6X   $!$ Текущий статус��6f   '   AllowAutoFilter' .  (   CellTemplate( 5=      �� 5>      .R�5?      �� ) �� Orientation$) 
Horizontal=�6)   $
��Left=�6B   $��Center=�6]   .+�5@   "   �� $ Aliased=�6(   $��20��6I   $ HighQuality=�6T   $��5 0 5 0q�6�   $��Center=�6�   ��6�   �� *RowData.Row.StatusIcon+6�   �� 5A   "   $��Center=�6W   ��6,   �� *RowData.Row.GetStatusTask+6W   5B      5C      5E        5G      $ Приоритет
 6!   $
 Task��64   $" 	Ascending=�6E   $# 5��6[   $!$ Текущий статус��6i   ' .  ( 5H      �� 5I      .R�5J      �� $) 
Horizontal=�6)   $
��Left=�6B   $��Center=�6]   .+�5K   "   �� $ Aliased=�6(   $��15��6I   $��15��6T   $��5 0 5 0q�6�   $��Center=�6�   ��6`   �� *RowData.Row.PriorityIcon+6�   �� 5L   "   $��Center=�6Y   ��6,   �� *RowData.Row.GetPriorityTask+6Y   5M      5N      5P      5Q      5R      �� 5T   
   -   5        $ 	gbProject��5T   /   $y�	Collapsed=�6   $8��2Текущие проекты сотрудника��6B   
�������$��2��6y   $��2��6�   .��5U        -   5        $ 	gcProject��5U       .  $
 None=�6R    . $
 None=�6�   	 5V        5W      |�.   .  .   .   .  ! .  $ Default=�6�   $ Default=�6�   . 5Y        $ Наименование
 6!   $
 Name��67   $" 	Ascending=�6H   $# 0��6^   $-$ 'Наименование проекта��6l   $
% True 6�   $
 True 6�   $& Contains=�6�     5Z      $ Дата начала
 6!   $ 	StartDate��66   $" 	Ascending=�6L   $# 1��6b   $@$ :Дата старта работы над проектом��6p   $
% True 6�   $
 True 6�   $ DateTime 6�     5[      $ Сроки 
 6!   $ EndDate��61   $" 	Ascending=�6E   $# 2��6[   $B$ <Предварительная дата завершения��6i   $
% True 6�   $
 True 6�   $ DateTime 6�     5\      $ CompletionDate��6!   $ Завершено
 6<   $# 3��6O   $4$ .Реальная дата завершения��6]    . $ DateTime 6�     5]      $ Тип
 6!   $ TypeProject��6.   $" 	Ascending=�6F   $# 5��6\   $($ "Продолжительность��6j   *   AllowBestFit$
* True 6�     5_      $ Статус
 6!   $ Project��61   $" 	Ascending=�6E   $# 6��6[   $!$ Текущий статус��6i   ' .  ( 5`      �� 5a      .R�5b      �� $) 
Horizontal=�6)   $
��Left=�6B   .+�5c   "   �� $ Aliased=�6(   $ HighQuality=�6I   $��5 0 5 0q�6�   ��6w   �� *RowData.Row.StatusIcon+6�   �� 5d   "   ��6,   �� *RowData.Row.GetStatusProject+5e      5f      5h      5j      5k      �� 5m   
   -   5        $ gbInfoWorker��5m   N   $��5 0 5 0q�6   $��14(�6)   $y�	Collapsed=�67   $��Статистика��6d   
�������$��0��6�   $��1��6�   .��5n      �� $) Vertical=�6   .+�5q      �� $) 
Horizontal=�6   .+�5r      �� $) Vertical=�6!   .+�5t      �� $) 
Horizontal=�6%   $��0 10 0 0q�6>   .+�5u      �� $��Center=�6)   $��Задач всего: ��6D   5v      �� 5x      $) 
Horizontal=�6%   $��0 10 0 5q�6>   .+�5y      �� -	   5        + ��Name$+ imgStatus02��5y       $��0 0 5 0q�65   $��Center=�6F   $6��0/StankoServiceApp;component/Resources/task02.png��6a   �� 5z      -
   5        , ��Name$, 
tbStatus02��5z   $   $��Center=�68   $��В работе: ��6S   5{      �� 5}      $) 
Horizontal=�6!   $��0 0 0 5q�6:   .+�5~      �� -   5        $+ imgStatus03��5~       $��0 0 5 0q�65   $��Center=�6F   $6��0/StankoServiceApp;component/Resources/task03.png��6a   �� 5      -   5        $, 
tbStatus03��5   $   $��Center=�68   $��Отменено: ��6S   5�      �� 5�      $) 
Horizontal=�6!   $��0 0 0 5q�6:   .+�5�      �� -   5        $+ imgStatus04��5�       $��0 0 5 0q�65   $��Center=�6F   $6��0/StankoServiceApp;component/Resources/task04.png��6a   �� 5�      -   5        $, 
tbStatus04��5�   $   $��Center=�68   $��Отложено: ��6S   5�      �� 5�      $) 
Horizontal=�6!   $��0 0 0 5q�6:   .+�5�      �� -   5        $+ imgStatus05��5�       $��0 0 5 0q�65   $��Center=�6F   $6��0/StankoServiceApp;component/Resources/task05.png��6a   �� 5�      -   5        $, 
tbStatus05��5�   $   $��Center=�68   $��Выполнено: ��6S   5�      �� 5�      $) 
Horizontal=�6!   $��0 0 0 5q�6:   .+�5�      �� -   5        $+ imgStatus06��5�       $��0 0 5 0q�65   $��Center=�6F   $6��0/StankoServiceApp;component/Resources/task06.png��6a   �� 5�      -   5        $, 
tbStatus06��5�   $   $��Center=�68   $��На проверке: ��6S   5�      5�      �� 5�      $) Vertical=�6!   .+�5�      �� -   5        $, tbCountTask��5�   $   $��5 10 0 0q�69   $��Center=�6K   $��На проверке: ��6f   �� 5�      -   5        $
, tb02��5�   $   $��5 10 0 0q�62   $��Center=�6D   $��На проверке: ��6_   �� 5�      -   5        $
, tb03��5�   $   $��5 6 0 5q�62   $��Center=�6C   $��На проверке: ��6^   �� 5�      -   5        $
, tb04��5�   $   $��5 2 0 5q�62   $��Center=�6C   $��На проверке: ��6^   �� 5�      -   5        $
, tb05��5�   $   $��5 0 0 5q�62   $��Center=�6C   $��На проверке: ��6^   �� 5�      -   5        $
, tb06��5�   $   $��5 2 0 5q�62   $��Center=�6C   $��На проверке: ��6^   5�      5�      5�      5�      (  "DevExpress.Xpf.Charts.ChartControl  5�   
   -   5        -  Name$- ccTerm��5�      .   AnimationMode$. OnDataChanged=�6+   $��1��6I   $��1��6Y   ,  &DevExpress.Xpf.Charts.ChartControlBase/   Legends/ 5�      "  DevExpress.Xpf.Charts.Legend  5�      0   VerticalPosition$	0 Top=�6   1   ItemVisibilityMode$1 AutoGeneratedAndCustom=�64   2   Titles2 5�      !  DevExpress.Xpf.Charts.Title  5�      %  DevExpress.Xpf.Charts.TitleBase3   Content$3 Успеваемость��6   4   HorizontalAlignment$4 Center=�63   $��16(�6P   5   Diagram.5 5�      +  %DevExpress.Xpf.Charts.SimpleDiagram2D  -   5        6  Name$6 sdTerm��5�   0   7   	Dimension$7 1��6"   #  DevExpress.Xpf.Charts.Diagram8   Series.8 5�      '  !DevExpress.Xpf.Charts.PieSeries2D  -   5        9  Name$9 seriesSimple��5�   "   %  DevExpress.Xpf.Charts.PieSeries:   HoleRadiusPercent$: 0Q�68   "  DevExpress.Xpf.Charts.Series;   LabelsVisibility; . <   LegendPointOptions< 5�      (  "DevExpress.Xpf.Charts.PointOptions  5�      =   Pattern$
= {A}:��6+   >   	PointView$> 
SeriesName=�6<   ?   PointOptions? 5�        5�      @   ValueNumericOptions@ 5�      *  $DevExpress.Xpf.Charts.NumericOptions  5�   "   A   Format$A Percent=�65   B   	Precision$B 0��6F   5�      5�      5�      5�      �� 5�   
   -   5        $ gbInfoManager��5�   O   $��5 0 5 0q�6   $��14(�6*   $y�	Collapsed=�68   $��Статистика��6f   
�������$��0��6�   $��1��6�   .��5�      �� $) Vertical=�6   .+�5�      �� $) 
Horizontal=�6   .+�5�      �� $) Vertical=�6!   .+�5�      �� $) 
Horizontal=�6%   $��0 10 0 5q�6>   .+�5�      �� -   5        $, tbCountProject��5�   (   $��Center=�6@   $#��Проектов всего: ��6[   5�      �� 5�      $) 
Horizontal=�6%   $��0 10 0 5q�6>   .+�5�      �� -   5        $, tbCountCurrent��5�   (   $��Center=�6@   $%��Текущие проекты: ��6[   5�      �� 5�      $) 
Horizontal=�6%   $��0 0 0 5q�6>   .+�5�      �� -   5        $+ imgStatus07��5�   $   $��0 0 5 0q�69   $��Center=�6J   $<��6/StankoServiceApp;component/Resources/lightblue.15.png��6e   �� 5�      -    5        $, 
tbStatus07��5�   (   $��Center=�6<   $��Завершено: ��6W   5�      �� 5�      $) 
Horizontal=�6%   $��0 0 0 5q�6>   .+�5�      �� -!   5        $+ imgStatus08��5�   $   $��0 0 5 0q�69   $��Center=�6J   $6��0/StankoServiceApp;component/Resources/red.15.png��6e   �� 5�      -"   5        $, 
tbStatus08��5�   (   $��Center=�6<   $��Отложено: ��6W   5�      �� 5�      $) 
Horizontal=�6%   $��0 0 0 5q�6>   .+�5�      �� -#   5        $+ imgStatus09��5�   $   $��0 0 5 0q�69   $��Center=�6J   $7��1/StankoServiceApp;component/Resources/gray.15.png��6e   �� 5�      -$   5        $, 
tbStatus09��5�   (   $��Center=�6<   $��Закрыто: ��6W   5�      �� 5�      $) 
Horizontal=�6%   $��0 5 0 5q�6>   .+�5�      �� $��Center=�6(   $��Создал задач: ��6C   5�      �� 5�      $) 
Horizontal=�6%   $��0 0 0 5q�6>   .+�5�      �� $��Center=�6(   $��Выполнено: ��6C   5�      5�      �� 5�      $) Vertical=�6!   .+�5�      �� -%   5        $, tbAllProject��5�   $   $��5 10 0 0q�6:   $��Center=�6L   $��На проверке: ��6g   �� 5�      -&   5        $, 	tbCurrent��5�   $   $��5 15 0 0q�67   $��Center=�6I   $��На проверке: ��6d   �� 5�      -'   5        $
, tb07��5�   $   $��5 5 0 5q�62   $��Center=�6C   $��На проверке: ��6^   �� 5�      -(   5        $
, tb08��5�   $   $��5 0 0 5q�62   $��Center=�6C   $��На проверке: ��6^   �� 5�      -)   5        $
, tb09��5�   $   $��5 0 0 5q�62   $��Center=�6C   $��На проверке: ��6^   �� 5�      -*   5        $, tbCountCreateTask��5�   $   $��5 5 0 5q�6?   $��Center=�6P   $��На проверке: ��6k   �� 5�      -+   5        $, tbCountApplyTask��5�   $   $��5 0 0 5q�6>   $��Center=�6O   $��На проверке: ��6j   5�      5�      5�      5�      �� 5�   
   $��3��6   $��2��6"   $) 
Horizontal=�66   $��Bottom=�6O   $��Right=�6j   $��	0 0 10 10q�6�   .+�5�      &   DevExpress.Xpf.Core.SimpleButton  -,   5        C  Name$C sbCancel��5�      $��Отменить��60   $��	10 10 0 0q�6o   D   GlyphAlignment$
D Left=�6�   E �� IsCancelE . F   GlyphF 6C   *  $DevExpress.Xpf.Core.DXImageExtension  G   Image1  +DevExpress.Xpf.Core.Native.DXImageConverter$G Cancel_32x32.png 6�     5�      --   5        $C sbSelect��5�      $��Выбрать��60   $��	10 10 0 0q�6m   H �� 	IsDefaultH . F 6B     $G Apply_32x32.png 6�   5�      5�      5�      