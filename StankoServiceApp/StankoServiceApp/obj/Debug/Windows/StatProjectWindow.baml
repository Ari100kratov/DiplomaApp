   M S B A M L   `   `   `  ����K  GStankoServiceApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:StankoServiceApp.WindowsStankoServiceApp.Windows  5   	   0    *StankoServiceApp.Windows.StatProjectWindow   5   	   f bDevExpress.Xpf.Grid.v17.1.Core, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   c _DevExpress.Xpf.Ribbon.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon  6I   a ]DevExpress.Xpf.Core.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49ae aDevExpress.Xpf.Printing.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aBdxp6http://schemas.devexpress.com/winfx/2008/xaml/printing   6�   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R	 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml 	    5   	   @d2http://schemas.microsoft.com/expression/blend/2008 	    5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006 	    5   	   8local&clr-namespace:StankoServiceApp.Windows 	    5   	   c
 _DevExpress.Xpf.Charts.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxc4http://schemas.devexpress.com/winfx/2008/xaml/charts 
 5   	   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  6J   <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  6�   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5   	   -   5        &   DevExpress.Xpf.Core.ThemeManager    	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$  Office2010Blue 5	   	    � Title$0 *Статистика по проектам��5   	   $	��600��6(   $	��800��65    � WindowStartupLocation$ CenterScreen=�6A   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   &   DevExpress.Xpf.Core.DXTabControl  -   5          Name$ dxTab��5   '   $��1��6   .@�5      #  DevExpress.Xpf.Core.DXTabItem  -   5          Name$	 dx1��5      �  �DevExpress.Xpf.Core.Native.HeaderedSelectorItemBase`2[[DevExpress.Xpf.Core.DXTabControl, DevExpress.Xpf.Core.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a],[DevExpress.Xpf.Core.DXTabItem, DevExpress.Xpf.Core.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]   Header$% Общая информация��6(   $��0��6B   .��5      � 
������ .+�5      ( 
 "DevExpress.Xpf.Charts.ChartControl  -   5          Name$ 
charCommon��5   E      AnimationMode$ OnDataChanged=�6'   , 
 &DevExpress.Xpf.Charts.ChartControlBase	   PrintOptions	 5      - 
 'DevExpress.Xpf.Charts.ChartPrintOptions  5      
   SizeMode$
 NonProportionalZoom=�64      Titles 5      !	 
 DevExpress.Xpf.Charts.Title	  5      %
 
 DevExpress.Xpf.Charts.TitleBase 
  Content$? 9Количесто проектов по статусам��6(    
  HorizontalAlignment$ Center=�6Q      Legends 5      " 
 DevExpress.Xpf.Charts.Legend  5         Diagram. 5!      ' 
 !DevExpress.Xpf.Charts.XYDiagram2D  -   5          Name$ diagrammCommon��5!   *   # 
 DevExpress.Xpf.Charts.Diagram   Series. 5"      1 
 +DevExpress.Xpf.Charts.BarSideBySideSeries2D  -   5          Name$ series1��5"   P   " 
 DevExpress.Xpf.Charts.Series   LabelsVisibility .    DisplayName$ Подготовка��6a   $ 
 DevExpress.Xpf.Charts.XYSeries   Brush$ 	#FFE8DF24��6z     5#      -   5        $ series2��5#   P    . $ 	#FF1B53CB��6a   $" Проектирование��6s     5$      -   5        $ series3��5$   P    . $ 	#FF44C51E��6a   $ Реализация��6s     5%      -	   5        $ series4��5%   P    . $ 	#FFF1A114��6a   $ Тестирование��6s     5&      -
   5        $ series5��5&   P    . $ 	#FFC56625��6a   $ Внедрение��6s     5'      -   5        $ series6��5'   P    . $ 	#FF982ED4��6a   $  Сопровождение��6s     5(      -   5        $ series7��5(   P    . $ 	#FF6EAFCD��6a   $ Завершен��6s     5)      -   5        $ series8��5)   P    . $ 	#FFEC1111��6a   $ Отложен��6s     5*      -   5        $ series9��5*   P    . $ 	#FFCFD3C3��6a   $ Закрыт��6s   5+      5,      5-      5.        5/      -   5        $	 dx2��5/   1   $ Успеваемость��6   $��1��6>   .��50      � 
������ .+�51        -   5        $ 	chartTerm��51   E   $ OnDataChanged=�6'   	 52        53      $
 NonProportionalZoom=�64    55      	  56      $T NДиаграмма успеваемости в заявленные сроки��6(   $ Center=�6\    58        59         UseCheckBoxes .  6)   . 5;      + 
 %DevExpress.Xpf.Charts.SimpleDiagram2D     	Dimension$ 1��6.   . 5<      ' 
 !DevExpress.Xpf.Charts.PieSeries2D  -   5          Name$ seriesSimple��5<   F    . % 
 DevExpress.Xpf.Charts.PieSeries   HoleRadiusPercent$ 0Q�6\      LegendTextPattern$ {A}:{VP}{V:%}��6r      LegendPointOptions 5>   "   ( 
 "DevExpress.Xpf.Charts.PointOptions  5?   &      Pattern$
 {A}:��67      PointOptions 5B   "     5C   &      ValueNumericOptions 5D   *   * 
 $DevExpress.Xpf.Charts.NumericOptions  5E   .      Format$ Percent=�6A       	Precision$  0��6R   5G   '   5I      5J      5K      5L      5M        5O      -   5        $	 dx3��5O   /   $ Активность��6   $��2��6<   .��5P      � 
������ .+�5Q        -   5        $ chartActivity��5Q   E   $ OnDataChanged=�6'    5R        5S      	 5U        5V      $
 NonProportionalZoom=�64    5X      	  5Y      $9 3Активность за последний год��6(   $ Center=�6N   . 5[        . 5\      ( 
 "DevExpress.Xpf.Charts.LineSeries2D  -   5        !  Name$! SeriesActvity��5\   /   $ Завершены��6G    . "   Points." 5]   "   ' 
 !DevExpress.Xpf.Charts.SeriesPoint  #   Argument$# 1��62   $   Value$	$ 6.5Q�6?     5^   "   $# 2��62   $	$ 5.5Q�6?     5_   "   $# 3��62   $
$ 12.5Q�6?     5`   "   $# 4��62   $
$ 11.5Q�6?     5a   "   $# 5��62   $
$ 18.5Q�6?   5b        5d      -   5        $! SeriesFalse��5d   /   $ Закрыты��6E    . ." 5e   "     $# 1��62   $$ 7Q�6?     5f   "   $# 2��62   $$ 10Q�6?     5g   "   $# 3��62   $$ 2Q�6?     5h   "   $# 4��62   $$ 3Q�6?     5i   "   $# 5��62   $$ 1Q�6?   5j      5k      5l      5n      5o      5p      )  #DevExpress.Xpf.Ribbon.RibbonControl  5r   
   $��0��6   %   RibbonStyle$% 
Office2010=�6)   &   ShowApplicationButton& .  '   IsHiddenRibbonCollapsed' .  %(   ToolbarShowCustomizationButton( . )   
Categories.) 5s      5  /DevExpress.Xpf.Ribbon.RibbonDefaultPageCategory  2  ,DevExpress.Xpf.Ribbon.RibbonPageCategoryBase*   Caption$* defaultCategory��6,   +   Pages.+ 5t      &   DevExpress.Xpf.Ribbon.RibbonPage  ,   Caption, 6!   Z� -   Groups.- 5u      +  %DevExpress.Xpf.Ribbon.RibbonPageGroup  .   Caption$. Печать��6*   /   Items./ 5v      '  !DevExpress.Xpf.Bars.BarButtonItem  -   5        0  Name$0 bbiPrintCurrent��5v   ,   !  DevExpress.Xpf.Bars.BarItem1   Content)  #DevExpress.Xpf.Core.ObjectConverter$1 Текущий 6E   2   RibbonStyle$2 Default=�6�   3   
LargeGlyph3 6W   *   $DevExpress.Xpf.Core.DXImageExtension   4    Image1!  +DevExpress.Xpf.Core.Native.DXImageConverter$4 Print_32x32.png! 5   Glyph5 6�      $4 Print_16x16.png! 6�   5w        5x      $. Экспорт��6*   ./ 5y        -   5        $
0 html��5y   ,   $
1 HTML 6:   5 6I      $4 ExportToHTML_16x16.png! 3 6{      $4 ExportToHTML_32x32.png! 6�     5z      -   5        $	0 img��5z   ,   $	1 IMG 69   5 6G      $4 ExportToIMG_16x16.png! 3 6x      $4 ExportToIMG_32x32.png! 6�     5{      -   5        $	0 mht��5{   ,   $	1 MHT 69   5 6G      $4 ExportToMHT_16x16.png! 3 6x      $4 ExportToMHT_32x32.png! 6�     5|      -   5        $	0 pdf��5|   ,   $	1 PDF 69   5 6G      $4 ExportToPDF_16x16.png! 3 6x      $4 ExportToPDF_32x32.png! 6�     5}      -   5        $	0 rtf��5}   ,   $	1 RTF 69   5 6G      $4 ExportToRTF_16x16.png! 3 6x      $4 ExportToRTF_32x32.png! 6�     5~      -   5        $	0 xls��5~   ,   $	1 XLS 69   5 6G      $4 ExportToXLS_16x16.png! 3 6x      $4 ExportToXLS_32x32.png! 6�     5      -   5        $
0 xlsx��5   ,   $
1 XLSX 6:   5 6I      $4 ExportToXLSX_16x16.png! 3 6{      $4 ExportToXLSX_32x32.png! 6�     5�      -   5        $	0 xps��5�   ,   $	1 XPS 69   5 6G      $4 ExportToXPS_16x16.png! 3 6x      $4 ExportToXPS_32x32.png! 6�   5�      5�      5�      5�      �� 5�   
   -   5        6 ��Name$6 tbCountDays��5�   !   $��2��6   $��0 5 0 5q�66   
���OO/�$��22(�6b   $��Center=�6p   $F��@Среднее количество дней на проект: ��6�   5�      5�      