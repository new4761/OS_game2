FROM ubuntu
RUN useradd -ms /bin/bash unity
WORKDIR /home/unity
COPY /gameserver_Data /home/unity/gameserver_Data/
COPY /gameserver.x86_64 /home/unity
RUN chown -R unity:unity /home/unity/gameserve*
USER unity


EXPOSE 7777-7787    


CMD ["./gameserver.x86_64", "-logFile", "/dev/stdout", "-batchmode", "-nographics"]
