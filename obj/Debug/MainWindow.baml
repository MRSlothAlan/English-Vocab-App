   M S B A M L   `   `   `  ����F  BEngVocabApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:EngVocabAppEngVocabApp  5   	       EngVocabApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:EngVocabApp     5   	   -   5          �Name$  EngVocabAppMainWindow��5   	    � Title$ 
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5	      !   EngVocabApp.EngVocabDataSet   engVocabDataSet  engVocabViewSource �� Source �� Source��%Y   &	        &	      7     5
   
   6    �� 5   
    6:   �� *
EngVocab+8   5      .��5      �  � DataContext# [ 6   $
��Left=�6=    � ColumnDefinitions 5   
   .+�5   
   �� $��Vocab:��6   $
��Left=�5      $��
190,30,0,0q�5      $	��Top=�5       J� RenderTransformOrigin$ 
0.511,0.53&�5      $��28��5      $��47��6   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ -0.051Q�6&   T� 5      	 T� X$	 -0.027Q�6)   
 T� Y$

 0.15Q�64   5      5      �� 5   
   -   5         ��Name$ AddToMemoButton��5      $��Add to memo��5       $
��Left=�5!      $��
194,95,0,0q�5"      $	��Top=�5#      $	��100��5$      6   �� 5%   
   -   5        $ GetFromMemoButton��5&      $��Get from memo��5'      $
��Left=�5(      $��
320,95,0,0q�5)      $	��Top=�5*      $	��100��5+      6   �� 5,   
   -   5         ��Name$ vocabTextBox��5,      $��30��6(   $��
250,30,0,0q�5-      $
��Left=�5.      $	��Top=�5/      $ 0.5,0.5&�50      $��16(�51   -   $	��200��52      .��6!   z�53      V� 54      .~�55      �� �� 56      �� 57      $ -0.051Q�6&   T� 58      $	 -0.027Q�6)   $
 0.061Q�64   59      .��5:   '   5;      �� 5<   
   -   5         ��Name$ vocabValidCheck_TextBox��5<      $��Label��5=      $
��Left=�5>      $��
370,60,0,0q�6/   $	��Top=�5?      $	��100��6,   &   System.Windows.Controls.DataGrid  5@   
   -   5          Name$ engVocabDataGrid��5@         AutoGenerateColumns .     EnableRowVirtualization . $��0,183,0.333,-0.333q�5B   +      RowDetailsVisibilityMode$ VisibleWhenSelected=�6G   $��2��5C   H   ��5B      ��    Columns 5E      0  *System.Windows.Controls.DataGridTextColumn  5F      -   5        idColumn��,  &System.Windows.Controls.DataGridColumn   Header$ Id��5F   N      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Id+6Z     5G      -   5        vocabColumn��$ Vocab��5G   T   $ 2* 6c    6:   �� *Vocab+6c     5H      -	   5        meaningColumn��$ Meaning��5H   X   $ 5* 6i    6<   �� *	Meaning+6i     5I      -
   5        InsertDateColumn��$ Insert Date��5I   ^   $ 2* 6s    6?   �� *
InsertDate+6s     5J      -   5        UpdateDateColumn��$ Update Date��5J   ^   $ 2* 6s    6?   �� *
UpdateDate+6s   5L      o� 5M   
   -   5         o�Name$ Actions��5M      $
��Left=�6    $	��110��6;   $	��Top=�6H   $	��125��6`   $ 
1.052,0.56&�6l   4  .System.Windows.Automation.AutomationProperties   IsOffscreenBehavior$ 	Offscreen=�6�   $��14(�6�   $��10,5,0,0q�6�   .@�5N      m� -   5         m�Name$ ResetDBMenuItem��5N      $��Reset Database��60   $��6,0,6,5q�6f   m� 5O      -   5        $ WordQuizMenuItem��5O      $��	Word Quiz��61   $��6,0,6,5q�6c   m� 5P      -   5        $ InsertWordMenuItem��5P      $��Insert Word��63   $��6,0,6,5q�6i   m� 5Q      -   5        $ SearchWordMenuItem��5Q      $��Search Word��63   $��6,0,6,5q�6i   5S      o� 5T   
   -   5        $ SelectWordMenu��5T      $
��Left=�6'   $	��100��6B   $��0q�6O   $	��Top=�6Z   $	��130��6r   $y�Hidden=�6~   $ 0.5,0.5&�6�    K� ZIndex$ 0��6�   $��16(�6�   $	��130��6�   $	��100��6�   .@�5V      m� -   5        $ SelectWordMenuUpdateWord��5V      $��Update Word��69   6N   m� 5W      -   5        $! SelectWordMenuAddNoteToWord��5W      $��	Add Notes��6<   m� 5X      -   5        $ SelectWordMenuDeleteWord��5X      $��Delete Word��69   6N   m� 5Y      -   5        $ SelectWordMenuQuit��5Y      $
��Quit��63   6A   5Z      �� 5[   
   -   5         ��Name$ suggestedWords_ListView��5[      $
��Left=�5\      $	��140��5]      $��
480,30,0,0q�6    $	��Top=�64   $	��300��5^      $	��300��5`      $��Disabled=�6"   $��Disabled=�5a      $��1��6G   ��5^      Z�  �� ItemBindingGroup 5b      &   System.Windows.Data.BindingGroup  5c       �� View 5e      �� 5f      .P�5g      �� $��Suggested words��6%    �� Width$	 300��6>   5h      5j      �� 5k   
   -   5        $ SearchAllWordsButton��5l      $��Search all words��5m      $
��Left=�5n      $��194,119,0,0q�5o      $	��Top=�5p      $	��100��5q      5r      5s      5t      