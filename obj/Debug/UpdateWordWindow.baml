   M S B A M L   `   `   `  ����F  BEngVocabApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:EngVocabAppEngVocabApp  5   	   "    EngVocabApp.UpdateWordWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:EngVocabApp     5   	   -   5          �Name$  UpdateWordWindow_Main��5   	    � Title$ Update Word��5   	   $	��320��6   $��499.7��6*   $	��500��68   $	��320��6G   $
��Auto=�6W   .��5	      � $��0,0,0.333,-0.333q�6   .+�5
   
   �  � ColumnDefinitions 5      �� 5      $
��121* �6#   �� 5      $
��372* �6#   .+�5      �� $��Original Spelling:��6   $
��Left=�61   $��	11,41,0,0q�6L   $	��Top=�6_   $��26��6w   $	��100��6�   �� 5      $��	Entry Id:��6   $
��Left=�6(   $��	58,15,0,0q�6C   $	��Top=�6V   $��26��6n   $��53��6z   �� 5      $��Original Meaning:��6   $
��Left=�60   $��5,72,0,0q�6K   $	��Top=�6]   $��26��6u   $	��106��6�   �� 5      $��Updated Spelling:��6   $
��Left=�60   $��	7,136,0,0q�6K   $	��Top=�6^   $��30��6v   $	��104��6�   �� 5      $��Updated Meaning:��6   $
��Left=�6/   $��	2,166,0,0q�6J   $	��Top=�6]   $��31��6u   $	��109��6�   �� 5      -   5         ��Name$ OriginalSpellingLabel��5      $��Label��63   $
��Left=�6C   $��130,41,252.333,0q�6^   $	��Top=�6x   &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�6�   $	��120��6�   $��2��6�   �� 5      -   5        $ OriginalMeaningLabel��5      $��Label��62   $
��Left=�6B   $��130,72,-227.667,0q�6]   $	��Top=�6x   $��45��6�   $	��600��6�   $	��350��6�   $��70��6�   $ Display=�6�   $��2��6�   �� 5      -   5         ��Name$ UpdatedSpellingTextBox��5      $��23��66   $��130,137,0,0q�6B    �� TextWrapping$
 Wrap=�6W   $��TextBox��6k   $	��Top=�6z   $ Display=�6�   $��16(�6�   $
��Left=�6�   $	��184��6	  $��2��6  �� 5      -   5        $ UpdatedMeaningTextBox��5      $��68��65   $��130,169,-236.667,0q�6A   $
 Wrap=�6]   $��TextBox��6q   $	��Top=�6�   $��70��6�   $	��350��6�   $ Display=�6�   $��2��6�   �� 5      -   5        $ OriginalIDLabel��5      $��Label��6-   $
��Left=�6=   $��130,15,72.333,0q�6X   $	��Top=�6q   $ Display=�6�   $	��300��6�   $��2��6�   �� 5      -   5        $ isValidSpellingLabel��5      $��Label��62   $
��Left=�6B   $��350,135,0,0q�6]   $	��Top=�6r   $��91��6�   $��2��6�   �� 5      -   5         ��Name$ Submit_Button��5      $��Submit��6,   $��130,261,0,0q�6=   $	��Top=�6R    J� RenderTransformOrigin$ 	0.016,0.5&�6j   $
��Left=�6�   $	��100��6�   $��2��6�   6�   5      5      5      