   M S B A M L   `   `   `  ����K  GStankoServiceApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:StankoServiceApp.WindowsStankoServiceApp.Windows  5   	   ,    &StankoServiceApp.Windows.ProfileWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:StankoServiceApp.Windows     5   	   c _DevExpress.Xpf.Ribbon.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon  5   	   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5   	   <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5	      j fDevExpress.Xpf.LayoutControl.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  5
   	   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5   	   -   5        &   DevExpress.Xpf.Core.ThemeManager    	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$  Office2010Blue 5   	    � Title$- 'Профиль пользователя��5   	   $	��700��6&   $	��500��63    � WindowStartupLocation$ CenterScreen=�6?    � SizeToContent$ WidthAndHeight=�6d   $��Visible=�6�   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   +  %DevExpress.Xpf.LayoutControl.GroupBox  4  .DevExpress.Xpf.Core.HeaderedContentControlBase   Header$+ %Личная инфомормация��6   
�������,  &DevExpress.Xpf.Core.ContentControlBase   Content. 5      0  *DevExpress.Xpf.LayoutControl.LayoutControl  .+�5      -  'DevExpress.Xpf.LayoutControl.LayoutItem  $	��200��6"   $
��Left=�61      Content. 5      �� -   5         ��Name$ imgPhoto��5   k   	 �� EdgeMode$	 Aliased=�6   
 �� BitmapScalingMode$
 HighQuality=�6=   $	��200��6}   5      .  (DevExpress.Xpf.LayoutControl.LayoutGroup  5         Orientation$ Vertical=�6#   .+�5            Label$ ФИО:��6&      
IsRequired . . 5!      �� -   5         ��Name$ tbFIO��5!   $   5"        5$      $ Дата рожд:��6&    . . 5%      �� -   5        $ tbDateOfBirth��5%   $   5&        5(      $ Телефон:��6&    . . 5)      �� -   5        $ tbPhone��5)   $   5*        5,      $ Работает с:��6&    . . 5-      �� -   5        $ tbDateOfEmploy��5-   $   5.        50      $ Должность:��6&    . . 51      �� -   5        $ 
tbPosition��51   $   52        54      $ E-mail:��6&    . . 55      �� -   5        $ tbEmail��55   $   56        58      -	   5          Name$	 li1��58   &   . 59      &	   DevExpress.Xpf.Core.SimpleButton	  -
   5         	 Name$ sbStatProject��59   �   $��Right=�6*   $	��200��6F   $
��Left=�6R   $3��-Статистика по проектам...��6t    	  Glyph 6�   4
  .DevExpress.Xpf.Core.DXImageOffice2013Extension
   
  Image;  5DevExpress.Xpf.Core.Native.DXImageOffice2013Converter$ Chart_16x16.png 6�   5:        5;      -   5        $	 li2��5;   &   . 5<      	  -   5        $ 
sbStatTask��5<   �   $��Right=�6*   $	��200��6F   $
��Left=�6R   $1��+Статистика по задачам...��6t    6�   
  $ Chart_16x16.png 6�   5=      5?      5A      5C        5F   
   $# Параметры входа��6   
�������$��1��6D   . 5G        $ Vertical=�6!   '  !DevExpress.Xpf.Core.ScrollControl   
ScrollBars$
 Auto=�68   .+�5I        $( "Электронная почта:��6"   . 5J      %  DevExpress.Xpf.Editors.TextEdit  -   5          Name$ teMail��5J   #   %  DevExpress.Xpf.Editors.BaseEdit   NullText$L FВведите новый адрес электронной почты��63      Mask$5 /[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}��6d      MaskType$ RegEx=�6�      MaskAutoComplete$ 
Optimistic=�6�   5K      �� 5M       �� Orientation$ 
Horizontal=�6   $��Right=�66   $y�Visible=�6R   .+�5N      	  -   5        $ 
sbEditMail��5N   f   $��Right=�6&   $��0 0 5 0q�6B   $��Изменить��6S    6z   *  $DevExpress.Xpf.Core.DXImageExtension     Image1  +DevExpress.Xpf.Core.Native.DXImageConverter$ Edit_16x16.png 6�   	  5O      -   5        $ sbNext��5O   &   $y�	Collapsed=�66   $
��ОК��6M   $��Right=�6Z    6v     $ IconSetSymbols3_16x16.png 6�   5P        5R      -   5        $ liCode��5R   "   $' !Код подтверждения��62    . $y�	Collapsed=�6^   . 5S        -   5        $ teCode��5S   #   $D >Код подтверждения выслан на почту��63   5T      �� 5V      -   5         ��Name$ 	spButtons��5V      $ 
Horizontal=�60   $��Right=�6I   $y�	Collapsed=�6e   .+�5W      	  -   5        $ sbRepeat��5W   &   $��0 0 5 0q�68   $"��Выслать еще раз��6I   $��Right=�6c    6     $ Reset2_16x16.png 6�   	  5X      -   5        $
 sbOK��5X   &   $
��ОК��65   $��Right=�6B    6^     $ IconSetSymbols3_16x16.png 6�   5Y      �� 5[      -   5        $ 	tbMessage��5[      $��5q�6/   $y�	Collapsed=�6:   $8��2Почта успешно подтверждена��6Q    �� TextAlignment$ Center=�6s   $��14(�6�   
��� � �6�     5^      -   5        $ liCurrentPassword��5^   "   $! Текущий пароль��6=   $y�Visible=�6U   $��0 10 0 0q�6j   . 5_      ,  &DevExpress.Xpf.Editors.PasswordBoxEdit  -   5          Name$ pbCurrentPassword��5_   *   5`        5b      -   5        $ liNewPassword��5b   "   $ Новый пароль��69   $y�Visible=�6O   . 5c        -   5        $ pbNewPassword��5c   *   5d        5f      -   5        $ liRepeatPassword��5f   "   $) #Подтвердите пароль��6<   $y�Visible=�6X   . 5g        -   5        $ pbRepeatPassword��5g   *   5h      5j      5l      �� 5n   
   -   5        $ tbMessageError��5n   ,   $��2��6   $��5q�6!   $y�	Collapsed=�6D   $:��4Заполните обязательные поля��6[   $��14(�6~   $ Center=�6�   
���\\��
�������6�   �� 5o   
   $��3��6   $ 
Horizontal=�6"   $��Right=�6<   $��	0 0 10 10q�6X   .+�5p      	  -   5        $ sbCancel��5p      $��Закрыть��60   $��	10 10 0 0q�6n    	  GlyphAlignment$
 Left=�6�    �� IsCancel .  6B     $ Cancel_32x32.png 6�   	  5q      -   5        $ sbSave��5q      $��Сохранить��6.   $��	10 10 0 0q�6m     �� 	IsDefault  .  6B     $ Apply_32x32.png 6�   5r      5s      5t      