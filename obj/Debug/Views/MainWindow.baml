   M S B A M L   `   `   `  ����>  :Bot, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Bot.Views.UserControlsBot.Views.UserControls  5   	       Bot.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   :d2http://schemas.microsoft.com/expression/blend/2008  5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Bot.Views.UserControls     5   	   -   5        $	��600��5	   	   $
��1080��6     � 
ResizeMode$  NoResize=�6#    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�6.   $��Dosis)�6A    � DataContext 5   	   �� *Main+   Locator �� Source# [  .��5      �  � ColumnDefinitions 5   
   �� 5      $	��270 �6   �� 5      $��* �6   �� 5      $	��270 �6   .+�5   
   �� $��0��6   
����  �.+�5      ��  �� Orientation$ 
Horizontal=�6   
�������.+�5      �� $	��300��6   $��80��6$   $"��..\Media\Images\450_1000.jpg��60   5      � 5       5      �� 5      $��* �6'   �� 5      $��* �6'   �� 5       $��* �6'   �� 5!      $��* �6'   .+�5$      ��   MaterialDesignFlatButton#��[ 6   $��0��6K   .��5%      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ History=�6.   
�������6=   5&      �� 5'      #��[ 6   $��1��6K   .��5(        $ People=�6.   
�������6<   5)      �� 5*      #��[ 6   $��2��6K   .��5+        $ Contacts=�6.   
�������6>   5,      �� 5-      #��[ 6   $��3��6K   .��5.        $ Archive=�6.   
�������6=   5/      50      �� 51      ��6   �� *Chats+ �� SelectedItem 64   �� *Chat+��54      �� 55      .R�57      � $��Center=�6   $��5q�6<    58      �� 59      $��50 �6/   �� 5:      $	��150 �6/   �� 5;      $	��50* �6/   .+�5>      �� $��40��6!   $��40��6,   	 �� CornerRadius$	 25��68   
�������$	��0.6q�6^   ��5?      �� 5@   "   
 �� ImageSource
 6-   ��  �� Path$ 
User.Photo�5B      �� 5C      $��10��6!   $��10��6,   $��Bottom=�68   $��5q�6S   $��Right=�6^   $	 15��6z   
������6�   �� 5E      $��1��6%   .+�5F      �� $
��10 0q�6C   ��6(   �� *	User.Name+6C   5G      �� 5I      $��2��6!   $��20��61   $��20��6<   $	 15��6H   
�������$��Center=�6m   $��Center=�6�   $��5q�6�   ._�5J      �� $��11(�6(     PrimaryHueDarkBrush#��[ 6W   $��Center=�6�   $��Center=�6�   ��66   �� *CountNewMessage+6�   5K      5L      5P      5R      5S      � 5W   
   $��1��6   ���	#FFE4E4E4.+�5X      �� $ 
Horizontal=�6   $	��100��62   $	��Top=�6?   ���	#FFE4E4E4 J� Effect 5Y      3  -System.Windows.Media.Effects.DropShadowEffect  5Z         
BlurRadius$ 30Q�6'      ShadowDepth$ 1Q�67   .+�5\      �� $��10��6   $��10��6$   $��Right=�60   $��15q�6L   
����  �$	 15��6j   $��Center=�6|   �� 5]      $��Dotnet9.com��6   $��28(�6/   $��Center=�6=   5`      ,   &Bot.Views.UserControls.UserControlChat  5a      $��Right=�6$   $	��540��6@   $��-10,105,10,60q�6L   �� 5c      
����·�$��Bottom=�6*   ._�5d      � $
��0 10q�6    5e      �� 5f      $��* �6+   �� 5g      $��70 �6+   �� 5h      $��70 �6+   �� 5i      $��70 �6+   .+�5k      �� $��0��6   $��80��6.    �� TextWrapping$
 Wrap=�6=   $��5q�6Q    �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=�6�   ��6\   �� *MessageText+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5l      $��3��6   $��Bottom=�6-    * &MaterialDesignFloatingActionMiniButton#��[ 6p   ��6J   �� *Add_Message_Click+.��5m        $
 Send=�62   5n      �� 5o      $��2��6   $��Bottom=�6D   #��[ 6_   ��6-   Z� .��5p        $ 
Attachment=�62   #��[ 6D   5q      �� 5r      $��1��63   $��Bottom=�6C   #��[ 6^   ��6   Z� .��5s        $ Smiley=�62   #��[ 6@   5t      5u      5v      5w      ,   &Bot.Views.UserControls.UserControlInfo  5z   
   $��2��6    $��Right=�60   $	��270��6L   5}      5~      