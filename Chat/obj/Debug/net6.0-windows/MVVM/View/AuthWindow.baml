   M S B A M L   `   `   `  ����?  ;Chat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Chat.MVVM.ViewChat.MVVM.View  5      9!clr-namespace:Chat.MVVM.ViewModelChat.MVVM.ViewModel  69       Chat.MVVM.View.AuthWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Chat.MVVM.View     5      7	viewmodel!clr-namespace:Chat.MVVM.ViewModel     69   $	��650��5      $
��1200��6   ���#36393F  � WindowStyle$
  None=�5
       � AllowsTransparency$
 True��5       � 
ResizeMode$ CanResizeWithGrip=�5       � DataContext 5      )  #Chat.MVVM.ViewModel.AuthWindowModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $��25 �6   �� 5      $��96 �6   �� 5      $
��426* �6   �� 5      $
��103* �6    � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      �� 5      $	��150 �6   .+�5   
   �� ��6   �� *SelectedViewModel+�� 5   
   -   5        $��3��5      ���#252525._�5       � $��Stretch=�6   .+�5!      �� $��
KucherChat��6   
�������$��SemiBold"�5#      �� 5$      $��Right=�6    �� Orientation$ 
Horizontal=�5%      $��1��6.   $��	120,0,0,0q�6>   $��60��6Q   .+�5&      �� -   5        $��20��5&      $��20��6(   $
��🗕��5'      
������ $��0q�5)      
�������$
��Bold"�5+      $��0,0,0,3q�5,      5-      �� 5.      -   5        $��20��5.      $��20��6(   $	��□��5/      
������ $��0q�51      
�������$
��Bold"�53      54      �� 55      -   5        $��20��55      $��20��6(   $��х��56      
������ $��0q�58      
�������$
��Bold"�5:      5;      5<      5=      5>      � 5?   
   $��1��6   $��1��5@      $��Center=�5A      $��Center=�5B      $��64��6,   $	��626��68   .+�5C      �� $	��Top=�6   $
��Left=�5D      $��SemiBold"�5E      $��40(�5F      
�������$3��-Добро пожаловать в KucherChat��5H      5I      � 5J   
   $��1��6   $��2��5K      $��Center=�5L      $��Center=�5M      $	��336��6*   $	��316��67   .+�5N      �� $ Vertical=�6   $��	0,0,0,-45q�60   .+�5O      � .+�5P      A� -   5         A�Name$ AvatarBorder��5P      $	��300��64   $	��300��6A   
���   �$��5��6\   A� 5Q      -   5        $ Avatar��5Q      $	��300��6.   $	��300��6;    J� RenderTransformOrigin$ 0.5,0.5&�6G   ��5R      �� 5S      -   5        UserImageBrush��	 �� ImageSource	 5S   A   �� *	UserImage+
 J� InputBindings
 5U      d� 5V       d� Gesture$ 	LeftClicka�6+    �� Command 6?   �� *SelectImageCommand+5X      5Y      �� 5Z      $��60��5[      $	��300��5\         UsernameInput#��[  5]      5_      5`      � 5a   
   $��3��6   $��1��5b      $��Center=�5c      $��Center=�5d      $��60��6,   $	��200��68   .+�5e      �� -   5         ��Name$ ConfirmButton��5e      $��Confirm��6,   
��� � �
�������$��25(�5g      $��60��6$   $	��200��5h      ��5i      �� *ConfirmCommand+5j      5k      5l      