   M S B A M L   `   `   `  ����K  GStankoServiceApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:StankoServiceApp.WindowsStankoServiceApp.Windows  5   	   ,    &StankoServiceApp.Windows.ManagerWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:StankoServiceApp.Windows     5   	   c _DevExpress.Xpf.Ribbon.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon  5   	   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5	   	   <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5
      -   5        &   DevExpress.Xpf.Core.ThemeManager    	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$
  none 5       � Title$8 2Форма управления менеджера��5   	   $	��500��6,   $	��500��69   $
��1000��6I    � WindowStartupLocation$ CenterScreen=�6V    � WindowState$ 	Maximized=�6{   $��0q�6�   ��. $
��Auto=�6�   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5       � ColumnDefinitions 5   
   �� 5      6!   �� 5      $
��auto �6   6.   .+�5   
   �� $
��10 0q�6   $��0��6#   $��0��60    �� Orientation$ 
Horizontal=�6@   .+�5      �� -   5        $��Мои проекты��5      
 J� Uid$ 0��6+   $��18(�63   $	��150��6A   $��50��6M   ���#6286BB��6Y   Z� ��6o   Z� 6�   �� 5      -   5        $��Мои задачи��5      $ 1��6*   $��18(�62   $	��150��6@   $��50��6L   ���#6286BB��6X   Z� ��6n   Z� 6�   �� 5      -   5        $��Сотрудники��5      $ 2��6.   $��18(�66   $	��150��6D   $��50��6P   ���#6286BB��6\   Z� ��6r   Z� 6�   5      �� 5    
   -   5         ��Name$ 
btnProfile��5    '   $��Мой профиль��6   $��1��6;   $��18(�6K   $��	10 0 10 0q�6Y   $��50��6m   ���#6286BB$��Right=�6�   ��6y   Z� ��6�   Z� 6�   � 5"   
   -   5        	 �Name$	 
GridCursor��5"      $
��10 0q�6   $	��150��61   $��5��6=   ���#6286BB$
��Left=�6]   $��Bottom=�6x   6�    � 5#   
   -   5        
  �Name$
 	MainFrame��5#   "   $��0 10 0 0q�6   $��1��65   $��2��6B     � NavigationUIVisibility$ Hidden=�6V   5$      5%      