# bustop_RestAPI
App과 MySQL 연결을 위한 RestAPI

### 아래 링크 참조하여 MySQL DB를 API화 시킴
 :link: [MySQL DB의 API화](https://velog.io/@dbsqja353/23.05.31-Day84)<br>
 
## Localhost가 아닌 게시된 ip주소와 통신하기 위해 다음과 같이 설정
### 1. bustop_RestAPI 디버그 후 Swagger 작동 확인 , 포트 번호 확인
### 2. .net 6.0 iis runtime x64 Download
:link: [iis runtime](https://dotnet.microsoft.com/ko-kr/download/dotnet/6.0)<br>
### 3. 인터넷 정보 서비스 활성화
- 아래 항목들 활성화

![](https://raw.githubusercontent.com/PKNU-IOT3/bustop_RestAPI/main/images/windows_onoff.png) 

### 4. 인바운드 규칙 설정
- 방화벽 및 네트워크 보호 - 인바운드 규칙 - 새 규칙 - tcp / 1번 포트번호 / 연결 허용

![](https://raw.githubusercontent.com/PKNU-IOT3/bustop_RestAPI/main/images/inbound.png) 

### 5. ASP.NET API 게시(폴더)
- 프로젝트 우클릭 게시 - 폴더 - 위치(C:\websites\bustop_api) - net6.0 - 하단 옵션 모두 적용

![](https://raw.githubusercontent.com/PKNU-IOT3/bustop_RestAPI/main/images/RestAPI_Release.png) 

### 6. iis 사이트 추가
- RestAPI_Server - 실제 경로 : 게시한 폴더 위치 - ipv4 주소 - 1번 포트번호

![](https://raw.githubusercontent.com/PKNU-IOT3/bustop_RestAPI/main/images/iis_site.png) 

## 유의사항
1. iis에서 서버 설정 시 port 번호를 7057로 설정, properties/launchSettings.json 파일에서 applicationUrl 또한 <br>
localhost:7057로 설정하게 되면 충돌이 발생하여 포트 번호는 다르게 설정
2. iis에서 서버를 실행하는 과정에서 500.19 problem / web.config 문제가 발생하요 dotnet hosting 6.0.0 다운로드
 :link: [dotnet hosting](https://www.c-sharpcorner.com/article/host-and-publish-net-core-6-web-api-application-on-iis-server2/)
3. Maui Project 권한 추가
- 프로젝트 - Platforms / Android / Resources / AndroidManifest.xml 에 권한 추가
- android:usesCleartextTraffic="true"
