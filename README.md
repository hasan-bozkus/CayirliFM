# Çayırlı FM v1.0.0 (.Net Core 7.0 )

## 📺 Çayırlı FM v1.0.0 - YouTube Oynatma Listesi (100 Bölüm) - YouTube Playlist (100 Episodes)
[![Çayırlı FM Asp.Net Core 7.0 Radyo Projesi](https://i.ytimg.com/vi/y7LnEfI_D7c/hqdefault.jpg?sqp=-oaymwEnCNACELwBSFryq4qpAxkIARUAAIhCGAHYAQHiAQoIGBACGAY4AUAB&rs=AOn4CLDcvc9cQMae68mWiK0k6uckcCctCg&title=%C3%87ay%C4%B1rl%C4%B1+FM+Asp.Net+Core+7.0+Radyo+Projesi&lang=tr&background_color=%230d1117&title_color=%23ffffff&stats_color=%23dedede&max_title_lines=2&width=300&border_radius=6)](https://www.youtube.com/playlist?list=PLwcourZzpnDZmpzdRg096qk-E5YYPlgtX)


> Yukarıdaki görsele tıklayarak 100 videoluk eğitim serisine ulaşabilirsiniz. <br />
> You can access the 100-video training series by clicking on the image above.


# Cayirli FM Web Radio - Music Player & Management System

Cayirli FM is a professional, music player management system built with **ASP.NET Core 7.0** and **N-Tier Architecture**. Designed for seamless music station management, podcast hosting, and listener engagement.


## 🌐 Çayırlı FM V2.0.0 Canlı - Demo

 [![Canlı Demo](https://img.shields.io/badge/Canl%C4%B1%20Demo-V2%20Professional-blue?style=for-the-badge&logo=internet-explorer)](https://cayirlifm.hasanbozkus.com.tr)

## 🚀 Key Features
* **Music and Player Management:** Add unlimited categories and tracks, create customized playlists.
* **Uninterrupted Listening Experience:** High-quality, fast audio streaming on any device with the responsive "Listen to Radio" interface.
* **Blog & News Module:** Increase audience engagement with industry news, announcements, and blog posts.
* **Advanced Event Calendar:** Announce tours, live streams, and events through a stylish calendar.
* **Mail and Communication Management:** An integrated mail system for managing messages and requests from listeners.

## 🛠 Tech Stack
* **Backend:** ASP.NET Core 7.0, C#, Entity Framework Core, SignalR
* **Architecture:** N-Tier Architecture, Repository Pattern, Dependency Injection
* **Frontend:** HTML5, CSS3, JavaScript, jQuery, Bootstrap 5
* **Database:** MS SQL Server (PostgreSQL and MySQL compatible architecture)

## 📋 Installation Guide

### 1. Database Setup
1. Create a new database in your SQL Server.
2. Include the `.bak` file provided in your database server.
3. Use the `.bak` file to populate the initial data.

### 2. Configuration
Open the `appsettings.json` file and update the server name and database name in the connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;initial catalog=YOUR_DB;integrated Security=True;TrustServerCertificate=true;Connection Timeout=30;"
}
```

3. Hosting Settings
For large podcast uploads (up to 1GB), ensure your web.config has the following settings:

```xml
<system.webServer>
  <security>
    <requestFiltering>
      <requestLimits maxAllowedContentLength="1073741824" />
    </requestFiltering>
  </security>
</system.webServer>
```
## 📬 Support
If you have any questions or need technical support, please contact us at bozkus.hasan@technoguide.com.tr
