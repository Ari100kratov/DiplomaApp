   M S B A M L   `   `   `  ����K  GStankoServiceApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:StankoServiceApp.WindowsStankoServiceApp.Windows  5   	   0    *StankoServiceApp.Windows.BeforePrintWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:StankoServiceApp.Windows     5   	   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5   
   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5	   	   &   DevExpress.Xpf.Core.ThemeManager    	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$  Office2010Blue 5
   	    � Title$3 -Выберите поля для вывода��5   	   $	��200��6*   $	��500��67    � SizeToContent$ WidthAndHeight=�6C    � WindowStartupLocation$ CenterScreen=�6b   .��5      � -   5         � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $ Vertical=�6   .+�5      )  #DevExpress.Xpf.Editors.ToggleSwitch  -   5          Name$ column1��5   #    d� 	IsChecked$
 TrueY�64   $��5q�6E      CheckedStateContent$ Наименование��6P   	   UncheckedStateContent$	 Наименование��6s     5      -   5        $ column2��5   #   $
 TrueY�64   $��5q�6E   $ Дата начала��6P   $	 Дата начала��6r     5      -   5        $ column3��5   #   $
 TrueY�64   $��5q�6E   $ Срок до��6P   $	 Срок до��6n   5      �� 5      $ Vertical=�6   .+�5        -   5        $ column4��5   #   $
 TrueY�64   $��5q�6E   $ Завершено��6P   $	 Завершено��6p     5      -   5        $ column5��5   #   $
 TrueY�64   $��5q�6E   $ Руководитель��6P   $	 Руководитель��6s     5      -   5        $ column6��5   #   $
 TrueY�64   $��5q�6E   $ Тип проекта��6P   $	 Тип проекта��6r   5       �� 5"      $ Vertical=�6   .+�5#        -   5        $ column7��5#   #   $
 TrueY�64   $��5q�6E   $ Статус��6P   $	 Статус��6m     5$      -	   5        $ column8��5$   #   $
 TrueY�64   $��5q�6E   $ Наименование��6P   $	 Наименование��6s     5%      -
   5        $ column9��5%   #   $
 TrueY�64   $��5q�6E   $ Наименование��6P   $	 Наименование��6s   5&      5(      �� 5)   
   $ 
Horizontal=�6   $��1��6.   $��5q�6;   $��Right=�6F   .+�5*      &   DevExpress.Xpf.Core.SimpleButton  -   5        
  Name$
 sbCancel��5*      $��Отменить��60   $��10 0 0 0q�6o      GlyphAlignment$
 Left=�6�    �� IsCancel .    Glyph 6C   *  $DevExpress.Xpf.Core.DXImageExtension     Image1  +DevExpress.Xpf.Core.Native.DXImageConverter$ Cancel_16x16.png 6�     5+      -   5        $
 sbSave��5+      $��Принять��6.   $��10 0 0 0q�6k    �� 	IsDefault .  6@     $ Apply_16x16.png 6�   5,      5-      5.      