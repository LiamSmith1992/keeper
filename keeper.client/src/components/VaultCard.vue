<template>
  <div v-if="vaults" class="">
    <router-link class="navbar-brand d-flex" :to="{ name: 'Vault', params: { vaultId: vaults?.id } }">

      <div class="selectable vault-img card img-fluid" :style="`background-image: url(${vaults.img})`">
        <div v-if="vaults.isPrivate == true" class="mdi mdi-lock"></div>
        <div class="bg-bg m-2 rounded">
          {{ vaults.name }}

        </div>
      </div>

    </router-link>
  </div>
</template>


<script>
import { RouterLink } from "vue-router";



export default {
  props: { vaults: { type: Object, required: true } },
  setup() {
    return {};
  },
  components: { RouterLink }
};
</script>


<style lang="scss" scoped>
.vault-img {
  height: 25vh;
  width: 100%;
  object-fit: cover;
  object-position: center;
  border: 3px rgba(37, 35, 35, 0.821) solid;
}

.bg-bg {
  background-color: rgba(0, 0, 0, 0.082);
  padding: 10px;
}
</style>