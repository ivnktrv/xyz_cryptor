```
___      ___ ___   ___   ________
\  \    /  / |  |  |  | |____   |
 \  \  /  /  |  \  /  /     /  /
  \  \/  /    \  \/  /     /  /
  /  /\  \     \    /     /  /
 /  /  \  \     \  /     /  /___
/__/    \__\    |__|    |______|

            ENCRYPTOR
```

**XYZ Encryptor** - программа, которая шифрует файлы. То есть она делает копию оригинального файла, но эта копия - зашифрованный ориг файл.

Команды:

```
           ─┐
xyz -h      |_  Справка
xyz --help  |
           ─┘                                        ─┐
xyz -e [файл] [название файла без расширения]         |_  Зашифровать файл. Выходной файл будет иметь расширение .xyz
xyz --encrypt [файл] [название файла без расширения]  |
                                                     ─┘
                         ─┐           
xyz -d [файл.xyz]         |_  Вывести расшифрованный текст на консоль
xyz --decrypt [файл.xyz]  |
                         ─┘
                                                     ─┐           
xyz -d [файл.xyz] --outfile [файл.расширение]         |_  Расшифровать .xyz файл и записать расшифрованные данные в файл.
xyz --decrypt [файл.xyz] --outfile [файл.расширение]  |
                                                     ─┘
```
***
**Например:**
- У нас есть картинка `image.png`:
<center>
    <img src="example/chipi chapa.png" width=300>
</center>

- Мы хотим его зашифровать:
`xyz -e "chipi chapa.png" ecnrypted_chipi_chapa`

- Создаётся файл `encrypted_chipi_chapa.xyz`.

<center>
    <img src="example/2.png">
</center>

- Далее отправляем этот файл какому-то челу и говорим что этот файл имеет расширение `.png`. Этот чел получает файл и с помощью этой проги его расшифровывает:
`xyz -d encrypted_chipi_chapa --outfile image.png`

<center>
    <img src="example/1.png">
</center>

- И вот наш расшифрованный чипи чапа : D

<center>
    <img src="example/image.png" width=300>
</center>