# TrayIcon
WPF aplikace, která pomocí Windows Forms knihovny zobrazuje ikonu běžící aplikace na hlavním panelu operačního systému Windows (vedle hodin). Ukazuje konfiguraci ikony a kontextové nabídky.
![Result](Resources/Result.png)

## Nastavení projektu
Pro využítí Windows Forms je potřeba přidat do projektu referenci:
![Win Forms Reference](Resources/WinFormsReference.png)

Ikonu je vhodné vložit do projektu jako zdroj (resource) aplikace:
![Icon](Resources/Icon.png)

Poté k ní lze přistoupit přímo z kódu:
```csharp
System.Windows.Forms.NotifyIcon _notifyIcon;
_notifyIcon.Icon = TrayIcon.Properties.Resources.Icon;
```
> TrayIcon je název namespace, ten je třeba změnit dle názvu Assebmly

## Aplikace 
