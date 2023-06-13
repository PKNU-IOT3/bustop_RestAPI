# bustop_RestAPI
App과 MySQL 연결을 위한 RestAPI

### 아래 링크 참조하여 MySQL DB를 API화 시킴
 :link: [MySQL DB의 API화](https://velog.io/@dbsqja353/23.05.31-Day84)<br>
 
## Localhost가 아닌 게시된 ip주소와 통신하기 위해 다음과 같이 설정
### 1. 인바운드 규칙 연결 허용
#### - 방화벽 및 네트워크 보호 - 인바운드 규칙 - (우클릭)새 규칙 - 포트 - TCP/특정 로컬 포트 - 7058 - 연결허용
![](https://raw.githubusercontent.com/PKNU-IOT3/bustop_RestAPI/main/images/defender.png) 
### 2. RestAPI 게시 및 iis 설정, Android 권한 변경
#### 1) Visual Studio - RestAPI - 게시
![](https://raw.githubusercontent.com/PKNU-IOT3/bustop_RestAPI/main/images/maui_server.png) 
#### 2) iis 설정
![](https://raw.githubusercontent.com/PKNU-IOT3/bustop_RestAPI/main/images/iis.png) 
#### 3) Maui Project / Platforms / Android / Resources / AndroidManifest.xml에 권한 추가
- android:usesCleartextTraffic="true"
