   M S B A M L   `   `   `  ����K  GStankoServiceApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:StankoServiceApp.WindowsStankoServiceApp.Windows  5   	   M IStankoserviceEnums, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS<clr-namespace:StankoserviceEnums;assembly=StankoserviceEnumsStankoserviceEnums 5
   	   -    'StankoServiceApp.Windows.EditTaskWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:StankoServiceApp.Windows     5   	   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5   	   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5   	   j fDevExpress.Xpf.LayoutControl.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  5	   	   UStankoserviceEnums<clr-namespace:StankoserviceEnums;assembly=StankoserviceEnums  5
   	   e aDevExpress.Xpf.RichEdit.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af	 bDevExpress.RichEdit.v17.1.Core, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aEdxre6http://schemas.devexpress.com/winfx/2008/xaml/richedit   	 5   	   f
 bDevExpress.Xpf.Grid.v17.1.Core, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid 
  5   	   -   5        &   DevExpress.Xpf.Core.ThemeManager    	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$  Office2010Blue 5   	    � Title$  ��5   	   $	��750��6   $	��500��6    � WindowStartupLocation$ CenterScreen=�6+    � SizeToContent$ WidthAndHeight=�6P   .��5      � .+�5   
   �� $
��Auto=�6   $
��Auto=�6:   .��5      �� .+�5      +  %DevExpress.Xpf.LayoutControl.GroupBox  4  .DevExpress.Xpf.Core.HeaderedContentControlBase   Header$* $Информация о задаче��6    
�������,  &DevExpress.Xpf.Core.ContentControlBase   Content. 5      0  *DevExpress.Xpf.LayoutControl.LayoutControl  .  (DevExpress.Xpf.LayoutControl.LayoutGroup   Orientation$ Vertical=�6)   .+�5      -  'DevExpress.Xpf.LayoutControl.LayoutItem     Label$ Наименование*��6*      
IsRequired . 	   Content.	 5      %	  DevExpress.Xpf.Editors.TextEdit	  -   5        
 	 Name$
 
teNameTask��5   +   %
  DevExpress.Xpf.Editors.BaseEdit 
  NullText$A ;Введите рабочее название задачи��6?   5        5      $+ %Родительская задача��6*   .	 5      +  %DevExpress.Xpf.Grid.LookUp.LookUpEdit  -   5          Name$ lueParentTask��5   -   +  %DevExpress.Xpf.Editors.LookUpEditBase   AutoComplete .    IncrementalFiltering$
 TrueX�5         ImmediatePopup .    IsPopupAutoWidth .     AutoPopulateColumns .  $L FВыберите частью какой задачи является��5   N      DisplayMember$ TaskName��6      ValueMember$ Id��6�   *  $DevExpress.Xpf.Editors.PopupBaseEdit   PopupContentTemplate 5!   "   �� 5"   &   .R�5#   *   %  DevExpress.Xpf.Grid.GridControl  $��PART_GridControl��6:   ) 
 #DevExpress.Xpf.Grid.DataControlBase   AutoGenerateColumns$
 None=�6S      SelectionMode$	 Row=�6n      View 5$   .   &   DevExpress.Xpf.Grid.TreeListView  5%   2      AutoExpandAllNodes . & 
  DevExpress.Xpf.Grid.DataViewBase   AllowEditing .     ShowAutoFilterRow .    ShowFilterPanelMode$ 
ShowAlways=�6�      ShowSearchPanelMode$ Default=�6�      	AutoWidth .    ParentFieldName$ ParentId��6�      KeyFieldName$ Id��6�       TreeDerivationMode$  Selfreference=�6	  !   Columns! 5'   .   $  DevExpress.Xpf.Grid.GridColumn  5(   2   $ 
 DevExpress.Xpf.Grid.BaseColumn"   Header)  #DevExpress.Xpf.Core.ObjectConverter$" Наименование 6A   $ 
 DevExpress.Xpf.Grid.ColumnBase#   	FieldName$# TaskName��6W   $   	SortOrder$$ 	Ascending=�6l   %   	SortIndex$% 0��6�   &   HeaderToolTip$+& %Наименование задачи��6�   '   AllowResizing] YDevExpress.Data.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5  /DevExpress.Utils.Design.DefaultBooleanConverter$
' True 6�   (   AllowMoving$
( True 6�   )   AutoFilterCondition$) Contains=�6�     5)   2   $" Менеджер 6A   $# Manager.FullName��6S   $$ 	Ascending=�6p   $% 1��6�   $-& 'Наименование проекта��6�   $
' True 6�   $
( True 6�   $) Contains=�6�     5*   2   $" Исполнитель 6A   $# Worker.FullName��6V   $$ 	Ascending=�6r   $% 2��6�   $2& ,ФИО испольнителя задачи��6�   $
' True 6�   $
( True 6�   $) Contains=�6�     5+   2   $" Проект 6A   $# Project.Name��6Q   $$ 	Ascending=�6j   $% 3��6�   $-& 'Наименование проекта��6�   $
' True 6�   $
( True 6�   $) Contains=�6�     5,   2   $" Срок до 6A   $# EndDate��6R   $$ 	Ascending=�6f   $% 4��6|   $H& BСроки завершения работы над задачей��6�   $
' True 6�   $
( True 6�   $) Contains=�6�     5-   2   $" Завершено 6A   $# CompletionDate��6T   $$ 	Ascending=�6o   $% 5��6�   $:& 4Фактическая дата завершения��6�   $
' True 6�   $
( True 6�   $) Contains=�6�     5/   2   $" Приоритет 6A   $
# Task��6T   $$ 	Ascending=�6e   $% 6��6{   $!& Текущий статус��6�   *   AllowAutoFilter* .  $) Contains=�6�   +   ColumnFilterMode$+ DisplayText=�6�   ,   CellTemplate, 50   6   �� 51   :   .R�52   >   �� - �� Orientation$- 
Horizontal=�6I   $
��Left=�6b   $��Center=�6}   .+�53   B   �� $��20��6H   $��20��6S   . �� EdgeMode$. Aliased=�6_   $��5 0 5 0q�6�   $��Center=�6�   ��6�   �� *RowData.Row.PriorityIcon+6�   �� 54   B   $��Center=�6y   ��6L   �� *RowData.Row.GetPriorityTask+6y   55   ?   56   ;   59   3     5;   2   $" Статус 6A   $
# Task��6Q   $$ 	Ascending=�6b   $% 7��6x   $!& Текущий статус��6�   * .  , 5<   6   �� 5=   :   .R�5>   >   �� $- 
Horizontal=�6I   $
��Left=�6b   $��Center=�6}   .+�5?   B   �� $��20��6H   $��20��6S   $. Aliased=�6_   $��5 0 5 0q�6�   $��Center=�6�   ��6�   �� *RowData.Row.StatusIcon+6�   �� 5@   B   $��Center=�6w   ��6L   �� *RowData.Row.GetStatusTask+6w   5A   ?   5B   ;   5D   3   5G   +   5H   '   5K      5L        5N      $ Проект��6*   .	 5O        -   5        $ 	ceProject��5R   N    . $
 TrueX�5P       .  .   .  $7 1Выберите проект для задачи��5R   a   $
 Name��6�   $ Id��6�    5T   "   �� 5U   &   .R�5V   *     $��PART_GridControl��6[   /   AllowInitiallyFocusedRow/ .  $
 None=�6s   #0   EnableSmartColumnsGeneration0 . $	 Row=�6�    5W   .   #  DevExpress.Xpf.Grid.TableView  5X   2   1   AllowPerPixelScrolling1 . 2   	AutoWidth2 . 3   ShowTotalSummary3 .  .  4   ShowAutoFilterRow4 . $ 
ShowAlways=�6�   $ Default=�6�   .! 5Z   .     $" Наименование 6=   $
# Name��6S   $$ 	Ascending=�6d   $% 0��6z   $-& 'Наименование проекта��6�   $
' True 6�   $
( True 6�   $) Contains=�6�     5[   .   $" Дата начала 6=   $# 	StartDate��6R   $$ 	Ascending=�6h   $% 1��6~   $@& :Дата старта работы над проектом��6�   $
' True 6�   $
( True 6�   5   UnboundType8  2DevExpress.Utils.Design.UnboundColumnTypeConverter$5 DateTime 6�     5\   .   $" Сроки  6=   $# EndDate��6M   $$ 	Ascending=�6a   $% 2��6w   $B& <Предварительная дата завершения��6�   $
' True 6�   $
( True 6�   $5 DateTime 6�     5]   .   $# CompletionDate��6=   $" Завершено 6X   $% 3��6k   $4& .Реальная дата завершения��6y   6   ReadOnly6 . $5 DateTime 6�     5^   .   $" Руководитель 6=   $# Worker.FullName��6S   $$ 	Ascending=�6o   $% 4��6�   $2& ,Ответственный за проект��6�   $) Contains=�6�     5_   .   $" Тип 6=   $# TypeProject��6J   $$ 	Ascending=�6b   $% 5��6x   $(& "Продолжительность��6�   7   AllowBestFit$
7 True 6�     5a   .   $" Статус 6=   $# Project��6M   $$ 	Ascending=�6a   $% 6��6w   $!& Текущий статус��6�   * .  , 5b   2   �� 5c   6   .R�5d   :   �� $- 
Horizontal=�6E   $
��Left=�6^   .+�5e   >   �� $. Aliased=�6D   $��5 0 5 0q�6�   ��6e   �� *RowData.Row.StatusIcon+6�   �� 5f   >   ��6H   �� *RowData.Row.GetStatusProject+5g   ;   5h   7   5j   /   5l   +   5m   '   5p      5q        5s      $% Сроки завершения��6*   .	 5t      %  DevExpress.Xpf.Editors.DateEdit  -   5        8  Name$8 	deEndDate��5t   +   $6 0Выберите срок заверешения��6>   5u        5w      $&  Приоритет задачи*��6*    . .	 5x      )  #DevExpress.Xpf.Editors.ComboBoxEdit  -   5        9  Name$9 
cePriority��5x   /   $6 0Выберите приоритет задачи��6C   :   ItemsSource: 6h   ,  &DevExpress.Xpf.Editors.EnumItemsSource  ;   EnumType$%; StankoserviceEnums:PriorityTaskL�<   UseNumericEnumValue< . 5y      5z        5|      -   5        =  Name$= liStatus��5|   *   $  Статус задачи*��6<    . .	 5}        -   5        $9 ceStatus��5}   /   $= 7Выберите статус задачи задачи��6A   : 6j     $#; StankoserviceEnums:StatusTaskL�< . 5~      5        5�      -	   5        $= 	liComment��5�   *   $ Комментарий��6=   .	 5�      %  DevExpress.Xpf.Editors.MemoEdit  -
   5        >  Name$> 	meComment��5�   +   $= 7Введите комментарий к статусу��6>   ?   ShowIcon? . 6g   5�        5�      -   5        $= liCompletionDate��5�   *   $ Завершена��6D   .	 5�        -   5        $8 deCompletionDate��5�   +   $K EВыберите фактическую дату завершения��6E   5�        5�      $ Описание��6*   .	 5�        -   5        $> meDescription��5�   +   5�      5�      5�        5�      $# Вложения задачи��6    
�������. 5�      �� $- 
Horizontal=�6!   $	��200��6:   $��Stretch=�6J   .+�5�        -   5        @  Name$@ gcFiles��5�   *   $
 None=�6;   $	 Row=�6V   / .  |�.  5�        5�   "   -   5        A  Name$A tvFile��5�   0    .  B   NavigationStyle$	B Row=�6U   &   DevExpress.Xpf.Grid.GridViewBaseC   ShowGroupPanelC .  6k   .! 5�        $# TaskFile.File��6-   $" Иконка 6G   $$ 	Ascending=�6W   $& Иконка файла��6n   D   VisibleIndex$D 0��6�   E   BestFitMode$E AllRows=�6�   , 5�   "   �� 5�   &   .R�5�   *   �� $- 
Horizontal=�65   $��Center=�6N   $��Center=�6k   .+�5�   .   �� $��25��64   $��25��6?   $. Aliased=�6K   $��5 0 5 0q�6�   $��Center=�6�   ��6l   �� *RowData.Row.FileIcon+6�   5�   +   5�   '   5�        5�      $" Файл 6-   $# FileName��6;   $$ 	Ascending=�6P   $% 0��6f   $)& #Наименование файла��6t   $
' True 6�   $
( True 6�   $) Contains=�6�   $D 1��6�     5�      $!" Дата изменения 6-   $# 
ChangeDate��6E   $$ 	Ascending=�6\   $% 2��6r   $A& ;Пользователь, изменивший статус��6�   $
' True 6�   $
( True 6�   $) Contains=�6�   $D 2��6�   $
7 True 6  F   BestFitArea$	F All=�6  5�      �� 5�      $- Vertical=�6%   $��5 0 5 0q�6<   $��Right=�6M   .+�5�      &   DevExpress.Xpf.Core.SimpleButton  -   5        G  Name$G sbDeleteFile��5�   @   {�.  $�� ��6V   $��0 0 0 5q�6a   H   GlyphH 6r   *  $DevExpress.Xpf.Core.DXImageExtension  I   Image1   +DevExpress.Xpf.Core.Native.DXImageConverter$I Delete_16x16.png  6�     5�      -   5        $G 
sbEditFile��5�   @   {�.  $�� ��6T   $��0 0 0 5q�6_   H 6p     $I Edit_16x16.png  6�     5�      -   5        $G 	sbAddFile��5�   .   $�� ��6A   H 6L     $I AddFile_16x16.png  6y   5�      5�      5�        5�      $ Исполнитель��6    
�������. 5�        .+�5�        $
��Left=�6*   .	 5�      �� -   5        J ��Name$J imgPhoto��5�   s   $. Aliased=�6$   K �� BitmapScalingMode$K HighQuality=�6E   $	��150��6�   $	��150��6�   5�        5�      $ Vertical=�6+   .+�5�        $ ФИО:��6.   .	 5�   "   �� -   5        L ��Name$L tbFIO��5�   ,   5�        5�      $ Дата рожд:��6.   .	 5�   "   �� -   5        $L tbDateOfBirth��5�   ,   5�        5�      $ Телефон:��6.   .	 5�   "   �� -   5        $L tbPhone��5�   ,   5�        5�      $ Работает с:��6.   .	 5�   "   �� -   5        $L tbDateOfEmploy��5�   ,   5�        5�      $ Должность:��6.   .	 5�   "   �� -   5        $L 
tbPosition��5�   ,   5�        5�      $ E-mail:��6.   .	 5�   "   �� -   5        $L tbEmail��5�   ,   5�      �� 5�      $- 
Horizontal=�6)   .+�5�   "     .	 5�   &     -   5        $G sbSelectWorker��5�   q   $
��Left=�66   $,��&Выбрать сотрудника...��6Q   $aH [pack://application:,,,/DevExpress.Images.v17.1;component/DevAV/Actions/ChangeView_16x16.png��6�   6�   5�   #     5�   "   $��10 0 0 0q�62   .	 5�   &     -   5        $G sbDeleteWorker��5�   j   $
��Left=�66   $!��Очистить выбор��6Q   H 6�     $I Clear_16x16.png  6�   5�   #   5�      5�      5�      5�      �� 5�      -   5        $L lblError��5�      $y�	Collapsed=�6.   M �� Padding$M 3q�6E   $K��EНеобходимо выбрать менеджера проекта��6Q   
���\\��
�������N �� TextAlignment$N Center=�6�   $��14(�6�   6�   �� 5�      $- 
Horizontal=�6   $��Right=�67   $��	0 0 10 10q�6S   .+�5�        -   5        $G sbCancel��5�   &   $��Отменить��68   $��	10 10 0 0q�6w   O   GlyphAlignment$
O Left=�6�   P �� IsCancelP . H 6K     $I Cancel_32x32.png  6�     5�      -   5        $G sbSave��5�   &   $��Сохранить��66   $��	10 10 0 0q�6u   Q �� 	IsDefaultQ . H 6J     $I Apply_32x32.png  6�   5�      5�      5�      5�      5�      