<template>
  <div class="listitem-component container-fluid">
    <div class="col-6 d-flex">
      <img :src="listItemProp.image" class="img-fluid radius15" />
      <div class="row card shadow radius15">
        <div class="col-12">
          <div class="ml-3">
            <h5>
              {{ listItemProp.title }}
            </h5>
            <p>${{ listItemProp.price }} </p>
            <p>Description: {{ listItemProp.body }}</p>
            <p>Quantity: {{ listItemProp.quantity }}</p>
            <button @click="removeFromList(listItemProp.id, listItemProp.listItemId)" class="btn border-0 bg-transparent text-danger">
              <p>Remove from list<i class="far fa-trash-alt ml-1"></i></p>
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
import { listItemsService } from '../services/ListItemService'
export default {
  name: 'ListitemComponent',
  props: ['listItemProp'],
  setup(props) {
    return {
      listItems: computed(() => props.listItemProp),
      removeFromList(itemId, listId) {
        listItemsService.removeFromList(itemId, listId)
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
img {
    max-width: 200px;
}
</style>
