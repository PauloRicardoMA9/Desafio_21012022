FROM mcr.microsoft.com/mssql/server:2019-CU14-ubuntu-20.04

ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=Your_password123

COPY ./data /

ENTRYPOINT [ "/bin/bash", "entrypoint.sh" ]
CMD [ "/opt/mssql/bin/sqlservr" ]