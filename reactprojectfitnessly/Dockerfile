# Gebruik een officiële Node.js image
FROM node:16 as build
WORKDIR /app

# Kopieer package.json en package-lock.json en installeer de afhankelijkheden
COPY package*.json ./
RUN npm install

# Gebruik een Nginx image om de app te serven
FROM nginx:alpine
COPY --from=build /app/dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
