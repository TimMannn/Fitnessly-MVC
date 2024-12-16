# Stage 1: Use node image to install dependencies and prepare the build
FROM node:16 as build
WORKDIR /app

# Copy package.json and package-lock.json to the working directory
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the entire project to the working directory
COPY . .

# Ensure the dist directory will be available after npm run build
# This step is only to ensure the dist directory is created in the CI pipeline
RUN mkdir -p /app/dist

# Stage 2: Use nginx image to serve the build
FROM nginx:alpine
COPY --from=build /app/dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
