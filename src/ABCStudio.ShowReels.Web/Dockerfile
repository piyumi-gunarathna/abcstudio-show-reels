FROM node:16-alpine3.15 As builder
WORKDIR /usr/src/app
COPY ABCStudio.ShowReels.Web/package.json ABCStudio.ShowReels.Web/package-lock.json ./
COPY . .
WORKDIR /usr/src/app/ABCStudio.ShowReels.Web
RUN npm install
RUN npm run build --prod
FROM nginx:1.15.8-alpine
COPY --from=builder /usr/src/app/ABCStudio.ShowReels.Web/dist/abcstudio.show-reels.web/ /usr/share/nginx/html